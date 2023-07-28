using Newtonsoft.Json;

namespace BingSamples.Web.Models;

public class TranslationModel
{
    [JsonProperty("translations")] public TranslationResponse[] Translations { get; set; }
}