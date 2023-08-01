using BingSamples.Web.Core;
using BingSamples.Web.Models;
using BingSamples.Web.Options;
using BingSamples.Web.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Options;

namespace BingSamples.Web.Pages.Bing;

public class SearchVideosPageModel : PageModel
{
    private readonly ILogger<SearchVideosPageModel> logger;
    private readonly BingSearchService bingSearchService;
    private readonly AppOptions appOptions;

    public SearchVideosPageModel(ILogger<SearchVideosPageModel> logger,
        BingSearchService bingSearchService,
        IOptions<AppOptions> appOptionsValue)
    {
        this.logger = logger;
        this.bingSearchService = bingSearchService;
        appOptions = appOptionsValue.Value;
        this.bingSearchService = bingSearchService;
    }

    public async Task<IActionResult> OnGetAsync(int? pageNumber)
    {
        logger.LogInformation("Loading Bing Search videos at {DateLoaded}", DateTime.Now);
        var page = pageNumber ?? 1;

        if (!string.IsNullOrEmpty(Query))
            SearchResults = await bingSearchService.SearchVideosAsync(page, appOptions.PageCount, Query);

        logger.LogInformation("Loaded SearchVideosPageModel page with query - {CurrentImageQuery}", Query);
        return Page();    
    }
    
    [BindProperty(SupportsGet = true)] public string Query { get; set; }
    [BindProperty] public PaginatedList<SearchVideosModel> SearchResults { get; set; } = new();
}