using BingSamples.Web.Core;
using BingSamples.Web.Models;
using BingSamples.Web.Options;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;

namespace BingSamples.Web.Services;

public class BingSearchService
{
    private readonly HttpClient client;
    private AppOptions appOptions;

    public BingSearchService(IOptions<AppOptions> optionsValue, HttpClient client)
    {
        this.client = client;
        appOptions = optionsValue.Value;
        client.BaseAddress = new Uri(WebConstants.SearchBaseEndpoint, UriKind.Absolute);
        client.DefaultRequestHeaders.Add("Ocp-Apim-Subscription-Key", appOptions.BingSubscriptionKey);
    }

    public async Task<PaginatedList<SearchModel>> SearchAsync(int page, int pageCount, string query,
        bool doHebrew = false)
    {
        var currentSearchData = $"search?q={Uri.EscapeDataString(query)}&responseFilter=-videos";

        var searchResponse = await client.GetAsync(currentSearchData);

        var list = new List<SearchModel>();

        if (searchResponse.IsSuccessStatusCode)
        {
            var contentString = await searchResponse.Content.ReadAsStringAsync();
            if (!string.IsNullOrEmpty(contentString))
            {
                var webPageResponse = JsonConvert.DeserializeObject<BingResponseObject>(contentString);
                foreach (var webPageDetail in webPageResponse.WebPagesResult.WebPageslist)
                {
                    list.Add(new SearchModel
                    {
                        Title = webPageDetail.Name,
                        Description = webPageDetail.Description,
                        UrlOrigin = webPageDetail.DisplayUrl
                    });
                }
            }
        }
        
        //todo: translate the description with translator

        return PaginatedList<SearchModel>.Create(list, page, pageCount, query);
    }
}