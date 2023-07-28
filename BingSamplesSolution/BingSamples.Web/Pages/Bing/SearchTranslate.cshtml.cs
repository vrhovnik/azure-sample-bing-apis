using BingSamples.Web.Core;
using BingSamples.Web.Models;
using BingSamples.Web.Options;
using BingSamples.Web.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Options;

namespace BingSamples.Web.Pages.Bing;

public class SearchTranslatePageModel : PageModel
{
    private readonly ILogger<SearchTranslatePageModel> logger;
    private readonly BingSearchService bingSearchService;
    private AppOptions appOptions;

    public SearchTranslatePageModel(ILogger<SearchTranslatePageModel> logger,
        BingSearchService bingSearchService,
        IOptions<AppOptions> appOptionsValue)
    {
        this.logger = logger;
        appOptions = appOptionsValue.Value;
        this.bingSearchService = bingSearchService;
    }

    public async Task<IActionResult> OnGetAsync(int? pageNumber)
    {
        logger.LogInformation("Loaded page Bing/SearchTranslate at {DateLoaded}", DateTime.Now);
        var page = pageNumber ?? 1;

        if (!string.IsNullOrEmpty(Query))
            SearchResults = await bingSearchService.SearchWithTranslationAsync(page, appOptions.PageCount, Query);

        logger.LogInformation("Loaded SearchPageModel page with query - {query}", Query);
        return Page();
    }

    [BindProperty(SupportsGet = true)] public string Query { get; set; }
    [BindProperty] public PaginatedList<SearchModel> SearchResults { get; set; } = new();
}