using BingSamples.Web.Core;
using BingSamples.Web.Interfaces;
using BingSamples.Web.Models;
using BingSamples.Web.Options;
using Htmx;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Options;

namespace BingSamples.Web.Pages.Bing;

public class SearchPageModel : PageModel
{
    private readonly ILogger<SearchPageModel> logger;
    private readonly IBingSearchService bingSearchService;
    private AppOptions appOptions;

    public SearchPageModel(ILogger<SearchPageModel> logger, 
        IBingSearchService bingSearchService,
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
        SearchResults = await bingSearchService.SearchAsync(page, appOptions.PageCount,Query);
        logger.LogInformation("Loaded SearchPageModel page with query - {query}", Query);
        
        if (Request.IsHtmx()) return Partial("_SearchList");
        return Page();
    }
    
    [BindProperty(SupportsGet = true)] public string Query { get; set; }
    [BindProperty] public PaginatedList<SearchModel> SearchResults { get; set; } = new();
}