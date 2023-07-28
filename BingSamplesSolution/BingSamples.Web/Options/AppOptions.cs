using System.ComponentModel.DataAnnotations;

namespace BingSamples.Web.Options;

public class AppOptions
{
    [Required(ErrorMessage = "Bing Subscription key is required")]
    public string BingSubscriptionKey { get; set; }
    [Required(ErrorMessage = "Translator Subscription key is required")]
    public string TranslatorSubscriptionKey { get; set; } 
    [Required(ErrorMessage = "Translator region name is required")]
    public string TranslatorRegion { get; set; }
    public int PageCount { get; set; }
}