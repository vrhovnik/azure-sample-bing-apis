using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BingSamples.Web.Pages.Bing;

public class SearchPageModel : PageModel
{
    private readonly ILogger<SearchPageModel> logger;

    public SearchPageModel(ILogger<SearchPageModel> logger)
    {
        this.logger = logger;
    }

    public void OnGet()
    {
        logger.LogInformation("Loaded page Bing/Search at {DateLoaded}", DateTime.Now);        
    }
}