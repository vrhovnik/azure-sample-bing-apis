using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BingSamples.Web.Pages;

public class IndexModel : PageModel
{
    private readonly ILogger<IndexModel> logger;

    public IndexModel(ILogger<IndexModel> logger) => this.logger = logger;

    public void OnGet() => logger.LogInformation("Loaded page Index/Info at {DateLoaded}", DateTime.Now);
}