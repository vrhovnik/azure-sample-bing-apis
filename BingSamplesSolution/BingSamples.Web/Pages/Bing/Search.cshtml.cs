using BingSamples.Web.Core;
using BingSamples.Web.Models;
using BingSamples.Web.Options;
using BingSamples.Web.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;

namespace BingSamples.Web.Pages.Bing;

public class SearchPageModel : PageModel
{
    private readonly ILogger<SearchPageModel> logger;
    private readonly BingSearchService bingSearchService;
    private AppOptions appOptions;

    public SearchPageModel(ILogger<SearchPageModel> logger,
        BingSearchService bingSearchService,
        IOptions<AppOptions> appOptionsValue)
    {
        this.logger = logger;
        appOptions = appOptionsValue.Value;
        this.bingSearchService = bingSearchService;
    }

    public async Task<IActionResult> OnGetAsync(int? pageNumber)
    {
        logger.LogInformation("Loaded page Bing/Search at {DateLoaded}", DateTime.Now);
        var page = pageNumber ?? 1;

        // if (!string.IsNullOrEmpty(Query))
        //     SearchResults = await bingSearchService.SearchAsync(page, appOptions.PageCount, Query);

        if (!string.IsNullOrEmpty(Query))
            SearchResults = await bingSearchService.SearchAsync(page, appOptions.PageCount,
                WebConstants.SearchBaseVirtual, Query, jsonResponse =>
                {
                    var list = new List<SearchModel>();
                    var webPageResponse = JsonConvert.DeserializeObject<BingResponseObject>(jsonResponse);
                    list.AddRange(webPageResponse.WebPagesResult.WebPageslist.Select(webPageDetail => new SearchModel
                    {
                        Title = webPageDetail.Name,
                        Description = webPageDetail.Description,
                        UrlOrigin = webPageDetail.DisplayUrl,
                        Image = webPageDetail.ThumbnailUrl
                    }));
                    return list;
                });

        logger.LogInformation("Loaded SearchPageModel page with query - {SearchQuery}", Query);
        return Page();
    }

    [BindProperty(SupportsGet = true)] public string Query { get; set; }
    [BindProperty] public PaginatedList<SearchModel> SearchResults { get; set; } = new();
}