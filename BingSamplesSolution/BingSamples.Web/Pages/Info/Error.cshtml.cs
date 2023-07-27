using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BingSamples.Web.Pages;

[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
[IgnoreAntiforgeryToken]
public class ErrorModel : PageModel
{
    public string RequestId { get; set; }

    public bool ShowRequestId => !string.IsNullOrEmpty(RequestId);

    private readonly ILogger<ErrorModel> logger;

    public ErrorModel(ILogger<ErrorModel> logger) => this.logger = logger;

    public void OnGet()
    {
        logger.LogInformation("Loaded page Error/Info at {DateLoaded}", DateTime.Now);
        RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier;
    }
}