using System.ComponentModel.DataAnnotations;

namespace BingSamples.Web.Options;

public class AppOptions
{
    [Required(ErrorMessage = "Subscription key is required")]
    public string SubscriptionKey { get; set; }
}