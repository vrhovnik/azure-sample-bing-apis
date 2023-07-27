using BingSamples.Web.Core;
using BingSamples.Web.Models;
using BingSamples.Web.Options;
using BingSamples.Web.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Options;

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

        var doHebrewValue = DoHebrew == "on";
        logger.LogInformation("Do hebrew was {HebrewTranslationValue}", DoHebrew);
        if (!string.IsNullOrEmpty(Query))
            SearchResults = await bingSearchService.SearchAsync(page, appOptions.PageCount, Query,
                doHebrewValue);

        logger.LogInformation("Loaded SearchPageModel page with query - {query}", Query);
        return Page();
    }

    [FromQuery(Name = "doHebrew")] public string DoHebrew { get; set; }
    [BindProperty(SupportsGet = true)] public string Query { get; set; }
    [BindProperty] public PaginatedList<SearchModel> SearchResults { get; set; } = new();
}