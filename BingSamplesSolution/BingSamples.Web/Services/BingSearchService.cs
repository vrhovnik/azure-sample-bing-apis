using BingSamples.Web.Core;
using BingSamples.Web.Models;
using BingSamples.Web.Options;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;

namespace BingSamples.Web.Services;

public class BingSearchService
{
    private readonly HttpClient client;
    private readonly BingTranslatorService bingTranslatorService;

    public BingSearchService(IOptions<AppOptions> optionsValue, HttpClient client,
        BingTranslatorService bingTranslatorService)
    {
        this.client = client;
        this.bingTranslatorService = bingTranslatorService;
        var appOptions = optionsValue.Value;
        client.BaseAddress = new Uri(WebConstants.SearchBaseEndpoint, UriKind.Absolute);
        client.DefaultRequestHeaders.Add("Ocp-Apim-Subscription-Key", appOptions.BingSubscriptionKey);
    }

    public async Task<PaginatedList<T>> SearchAsync<T>(int page, int pageCount, string virtualPath, string query,
        Func<string, List<T>> func)
    {
        var currentSearchData = $"{virtualPath}?q={Uri.EscapeDataString(query)}";

        var searchResponse = await client.GetAsync(currentSearchData);

        var list = new List<T>();

        if (!searchResponse.IsSuccessStatusCode) return PaginatedList<T>.Create(list, page, pageCount, query);

        var contentString = await searchResponse.Content.ReadAsStringAsync();

        if (string.IsNullOrEmpty(contentString)) return PaginatedList<T>.Create(list, page, pageCount, query);

        list = func(contentString);

        return PaginatedList<T>.Create(list, page, pageCount, query);
    }

    public async Task<PaginatedList<SearchModel>> SearchAsync(int page, int pageCount, string query)
    {
        var currentSearchData = $"search?q={Uri.EscapeDataString(query)}";

        var searchResponse = await client.GetAsync(currentSearchData);

        var list = new List<SearchModel>();

        if (!searchResponse.IsSuccessStatusCode) return PaginatedList<SearchModel>.Create(list, page, pageCount, query);

        var contentString = await searchResponse.Content.ReadAsStringAsync();

        if (string.IsNullOrEmpty(contentString)) return PaginatedList<SearchModel>.Create(list, page, pageCount, query);

        var webPageResponse = JsonConvert.DeserializeObject<BingResponseObject>(contentString);
        list.AddRange(webPageResponse.WebPagesResult.WebPageslist.Select(webPageDetail => new SearchModel
        {
            Title = webPageDetail.Name,
            Description = webPageDetail.Description,
            UrlOrigin = webPageDetail.DisplayUrl,
            Image = webPageDetail.ThumbnailUrl
        }));

        return PaginatedList<SearchModel>.Create(list, page, pageCount, query);
    }

    public async Task<PaginatedList<SearchImageModel>> SearchImagesAsync(int page, int pageCount, string query)
    {
        var currentSearchData = $"images/search?q={Uri.EscapeDataString(query)}";

        var searchResponse = await client.GetAsync(currentSearchData);
        var list = new List<SearchImageModel>();

        if (!searchResponse.IsSuccessStatusCode)
            return PaginatedList<SearchImageModel>.Create(list, page, pageCount, query);

        var contentString = await searchResponse.Content.ReadAsStringAsync();

        if (string.IsNullOrEmpty(contentString))
            return PaginatedList<SearchImageModel>.Create(list, page, pageCount, query);

        var webPageResponse = JsonConvert.DeserializeObject<BingImageResponse>(contentString);
        list.AddRange(webPageResponse.BingImages.Select(webPageDetail =>
            new SearchImageModel
            {
                ImageUrl = webPageDetail.ContentUrl,
                AltText = webPageDetail.Name.Truncate(30)
            }));

        return PaginatedList<SearchImageModel>.Create(list, page, pageCount, query);
    }

    public async Task<PaginatedList<SearchVideosModel>> SearchVideosAsync(int page, int pageCount, string query)
    {
        var currentSearchData = $"videos/search?q={Uri.EscapeDataString(query)}";

        var searchResponse = await client.GetAsync(currentSearchData);
        var list = new List<SearchVideosModel>();

        if (!searchResponse.IsSuccessStatusCode)
            return PaginatedList<SearchVideosModel>.Create(list, page, pageCount, query);

        var contentString = await searchResponse.Content.ReadAsStringAsync();

        if (string.IsNullOrEmpty(contentString))
            return PaginatedList<SearchVideosModel>.Create(list, page, pageCount, query);

        var webPageResponse = JsonConvert.DeserializeObject<BingVideoResponse>(contentString);
        list.AddRange(webPageResponse.BingVideoResults.Select(webPageDetail =>
            new SearchVideosModel
            {
                Author = webPageDetail.Creator?.Name,
                Description = webPageDetail.Description.Truncate(),
                ThumbnailUrl = webPageDetail.ThumbnailUrl ?? string.Empty,
                Url = webPageDetail.ContentUrl,
                DatePublished = webPageDetail.DatePublished ?? string.Empty
            }));

        return PaginatedList<SearchVideosModel>.Create(list, page, pageCount, query);
    }

    public async Task<PaginatedList<SearchNewsModel>> SearchNewsAsync(int page, int pageCount, string query)
    {
        var currentSearchData = $"news/search?q={Uri.EscapeDataString(query)}";

        var searchResponse = await client.GetAsync(currentSearchData);
        var list = new List<SearchNewsModel>();

        if (!searchResponse.IsSuccessStatusCode)
            return PaginatedList<SearchNewsModel>.Create(list, page, pageCount, query);

        var contentString = await searchResponse.Content.ReadAsStringAsync();

        if (string.IsNullOrEmpty(contentString))
            return PaginatedList<SearchNewsModel>.Create(list, page, pageCount, query);

        var webPageResponse = JsonConvert.DeserializeObject<BingNewsResponse>(contentString);
        list.AddRange(webPageResponse.News.Select(webPageDetail =>
            new SearchNewsModel
            {
                Title = webPageDetail.Name,
                Description = webPageDetail.Description.Truncate(),
                Url = webPageDetail.Url
            }));

        return PaginatedList<SearchNewsModel>.Create(list, page, pageCount, query);
    }

    public async Task<PaginatedList<SearchSuggestionModel>> SearchSuggestionsAsync(int page, int pageCount,
        string query)
    {
        var currentSearchData = $"{WebConstants.SearchSuggestionsVirtual}?Query={Uri.EscapeDataString(query)}";

        var searchResponse = await client.GetAsync(currentSearchData);
        var list = new List<SearchSuggestionModel>();

        if (!searchResponse.IsSuccessStatusCode)
            return PaginatedList<SearchSuggestionModel>.Create(list, page, pageCount, query);

        var contentString = await searchResponse.Content.ReadAsStringAsync();

        if (string.IsNullOrEmpty(contentString))
            return PaginatedList<SearchSuggestionModel>.Create(list, page, pageCount, query);

        var webPageResponse = JsonConvert.DeserializeObject<BingSuggestionResponse>(contentString);
        list.AddRange(collection: webPageResponse.SuggestionGroups.Select(webPageDetail =>
            new SearchSuggestionModel
            {
                Title = webPageDetail.Name,
                Details = webPageDetail.SearchSuggestions.Select(display =>
                    new SearchSuggestionDetail(display.DisplayText, display.Url)).ToList()
            }));

        return PaginatedList<SearchSuggestionModel>.Create(list, page, pageCount, query);
    }

    public async Task<PaginatedList<SearchModel>> SearchWithTranslationAsync(int page, int pageCount, string query)
    {
        var results = await SearchAsync(page, pageCount, query);
        foreach (var searchModel in results)
            searchModel.Description = await bingTranslatorService.GetTranslatedTextAsync(searchModel.Description);

        return results;
    }
}