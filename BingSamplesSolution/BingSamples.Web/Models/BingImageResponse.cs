using Newtonsoft.Json;

namespace BingSamples.Web.Models;

public class BingImageResponse
{
    //public string _type { get; set; }
    //public Instrumentation instrumentation { get; set; }
    [JsonProperty("readLink")]
    public string VirtualImageUrl { get; set; }
    [JsonProperty("webSearchUrl")]
    public string WebSearchUrl { get; set; }
    [JsonProperty("totalEstimatedMatches")]
    public int ImagesCount { get; set; }
    [JsonProperty("nextOffset")]
    public int NextOffset { get; set; }
    [JsonProperty("value")]
    public BingImageDetail[] BingImages { get; set; }
}

public class BingImageDetail
{
    [JsonProperty("webSearchUrl")]
    public string WebSearchUrl { get; set; }
    [JsonProperty("name")]
    public string Name { get; set; }
    [JsonProperty("thumbnailUrl")]
    public string ThumbnailUrl { get; set; }
    [JsonProperty("datePublished")]
    public string DatePublished { get; set; }
    [JsonProperty("contentUrl")]
    public string ContentUrl { get; set; }
    [JsonProperty("hostPageUrl")]
    public string HostPageUrl { get; set; }
    [JsonProperty("contentSize")]
    public string ContentSize { get; set; }
    [JsonProperty("encodingFormat")]
    public string EncodingFormat { get; set; }
    [JsonProperty("hostPageDisplayUrl")]
    public string HostPageDisplayUrl { get; set; }
    [JsonProperty("width")]
    public int Width { get; set; }
    [JsonProperty("height")]
    public int Height { get; set; }
    [JsonProperty("thumbnail")]
    public ImageThumbnail ThumbnailSize { get; set; }
    [JsonProperty("accentColor")]
    public string AccentColor { get; set; }
}

public class ImageThumbnail
{
    [JsonProperty("width")]
    public int Width { get; set; }
    [JsonProperty("height")]
    public int Height { get; set; }
}

public class InsightsMetadata
{
    [JsonProperty("bestRepresentativeQuery")]
    public BestRepresentativeQuery BestRepresentativeQuery { get; set; }
    public int pagesIncludingCount { get; set; }
    public int availableSizesCount { get; set; }
}

public class BestRepresentativeQuery
{
    [JsonProperty("text")]
    public string Text { get; set; }
    [JsonProperty("displayText")]
    public string Displaytext { get; set; }
    [JsonProperty("webSearchUrl")]
    public string Websearchurl { get; set; }
}

