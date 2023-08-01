using BingSamples.Web.Core;
using BingSamples.Web.Models;
using BingSamples.Web.Options;
using BingSamples.Web.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Options;

namespace BingSamples.Web.Pages.Bing;

public class SearchImagesPageModel : PageModel
{
    private readonly ILogger<SearchImagesPageModel> logger;
    private readonly BingSearchService bingSearchService;
    private readonly AppOptions appOptions;

    public SearchImagesPageModel(ILogger<SearchImagesPageModel> logger,
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
        logger.LogInformation("Loading Bing Search Images at {DateLoaded}", DateTime.Now);
        var page = pageNumber ?? 1;

        if (!string.IsNullOrEmpty(Query))
            SearchResults = await bingSearchService.SearchImagesAsync(page, appOptions.PageCount, Query);

        logger.LogInformation("Loaded SearchImagesPerModel page with query - {CurrentImageQuery}", Query);
        return Page();    
    }
    
    [BindProperty(SupportsGet = true)] public string Query { get; set; }
    [BindProperty] public PaginatedList<SearchImageModel> SearchResults { get; set; } = new();
}