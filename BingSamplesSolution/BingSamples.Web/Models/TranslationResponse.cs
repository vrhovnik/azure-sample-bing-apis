using Newtonsoft.Json;

namespace BingSamples.Web.Models;

public class TranslationResponse
{
    [JsonProperty("text")] public string Text { get; set; }

    [JsonProperty("to")] public string To { get; set; }
}