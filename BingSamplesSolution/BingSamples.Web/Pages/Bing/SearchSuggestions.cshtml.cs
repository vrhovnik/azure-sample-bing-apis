using BingSamples.Web.Core;
using BingSamples.Web.Models;
using BingSamples.Web.Options;
using BingSamples.Web.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;

namespace BingSamples.Web.Pages.Bing;

public class SearchSuggestionsPageModel : PageModel
{
    private readonly ILogger<SearchSuggestionsPageModel> logger;
    private readonly BingSearchService bingSearchService;
    private AppOptions appOptions;

    public SearchSuggestionsPageModel(ILogger<SearchSuggestionsPageModel> logger,
        BingSearchService bingSearchService,
        IOptions<AppOptions> appOptionsValue)
    {
        this.logger = logger;
        appOptions = appOptionsValue.Value;
        this.bingSearchService = bingSearchService;
    }

    public async Task<IActionResult> OnGetAsync(int? pageNumber)
    {
        logger.LogInformation("Loaded page Bing/SearchSuggestions at {DateLoaded}", DateTime.Now);
        var page = pageNumber ?? 1;

        if (!string.IsNullOrEmpty(Query))
            SearchResults = await bingSearchService.SearchSuggestionsAsync(page, appOptions.PageCount, Query);

        logger.LogInformation("Loaded SearchSuggestions page with query - {SearchQuery}", Query);
        return Page();
    }

    [BindProperty(SupportsGet = true)] public string Query { get; set; }
    [BindProperty] public PaginatedList<SearchSuggestionModel> SearchResults { get; set; } = new();
}