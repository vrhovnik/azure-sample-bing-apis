using BingSamples.Web.Core;
using BingSamples.Web.Interfaces;
using BingSamples.Web.Models;
using BingSamples.Web.Options;
using Microsoft.Azure.CognitiveServices.Search.WebSearch;
using Microsoft.Extensions.Options;

namespace BingSamples.Web.Services;

public class BingSearchService : IBingSearchService
{
    private AppOptions appOptions;
    private readonly WebSearchClient client;

    public BingSearchService(IOptions<AppOptions> optionsValue)
    {
        appOptions = optionsValue.Value;
        client = new WebSearchClient(new ApiKeyServiceClientCredentials(appOptions.SubscriptionKey));
    }

    public async Task<PaginatedList<SearchModel>> SearchAsync(int page, int pageCount, string query)
    {
        var searchResponse = await client.Web.SearchAsync(query: query);
        var list = new List<SearchModel>();
        if (searchResponse?.WebPages?.Value?.Count > 0)
        {
            var pages = searchResponse.WebPages.Value;
            foreach (var currentWebPage in pages)
            {
                list.Add(new SearchModel
                {
                    Title = currentWebPage.Text,
                    Description = currentWebPage.Description,
                    UrlOrigin = currentWebPage.WebSearchUrl,
                    Image = currentWebPage.ThumbnailUrl
                });
            }
        }

        return PaginatedList<SearchModel>.Create(list, page, pageCount, query);
    }
}