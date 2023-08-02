using Newtonsoft.Json;

namespace BingSamples.Web.Models;

public class BingSuggestionResponse
{
    public string _type { get; set; }
    [JsonProperty("queryContext")]
    public BingSuggestionQueryContext QueryContext { get; set; }
    [JsonProperty("suggestionGroups")]
    public SuggestionGroups[] SuggestionGroups { get; set; }
}

public class BingSuggestionQueryContext
{
    [JsonProperty("originalQuery")]
    public string Query { get; set; }
}

public class SuggestionGroups
{
    [JsonProperty("name")]
    public string Name { get; set; }
    [JsonProperty("searchSuggestions")]
    public SearchSuggestions[] SearchSuggestions { get; set; }
}

public class SearchSuggestions
{
    [JsonProperty("url")]
    public string Url { get; set; }
    [JsonProperty("displayText")]
    public string DisplayText { get; set; }
    [JsonProperty("query")]
    public string Query { get; set; }
    public string searchKind { get; set; }
}

