using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BingSamples.Web.Pages.Bing;

public class IndexPageModel : PageModel
{
    private readonly ILogger<IndexPageModel> logger;

    public IndexPageModel(ILogger<IndexPageModel> logger) => this.logger = logger;

    public void OnGet() => logger.LogInformation("Loaded page Bing/Info at {DateLoaded}", DateTime.Now);
}