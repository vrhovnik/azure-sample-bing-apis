using Newtonsoft.Json;

namespace BingSamples.Web.Models;

public class BingVideoResponse
{
    public string readLink { get; set; }
    [JsonProperty("webSearchUrl")]
    public string WebSearchUrl { get; set; }
    [JsonProperty("value")]
    public BingVideoDetail[] BingVideoResults { get; set; }
    public VideoRelatedSearches[] relatedSearches { get; set; }
}

public class BingVideoDetail
{
    [JsonProperty("webSearchUrl")]
    public string WebSearchUrl { get; set; }
    [JsonProperty("name")]
    public string Name { get; set; }
    [JsonProperty("description")]
    public string Description { get; set; }
    [JsonProperty("thumbnailUrl")]
    public string ThumbnailUrl { get; set; }
    [JsonProperty("datePublished")]
    public string DatePublished { get; set; }
    [JsonProperty("publisher")]
    public VideoPublisher[] Publishers { get; set; }
    [JsonProperty("creator")]
    public VideoCreator Creator { get; set; }
    public bool isAccessibleForFree { get; set; }
    public bool isFamilyFriendly { get; set; }
    [JsonProperty("contentUrl")]
    public string ContentUrl { get; set; }
    public string hostPageUrl { get; set; }
    public string encodingFormat { get; set; }
    public string hostPageDisplayUrl { get; set; }
    public int width { get; set; }
    public int height { get; set; }
    [JsonProperty("duration")]
    public string Duration { get; set; }
    public string motionThumbnailUrl { get; set; }
    [JsonProperty("embedHtml")]
    public string EmbedHtml { get; set; }
    public bool allowHttpsEmbed { get; set; }
    public int viewCount { get; set; }
    [JsonProperty("thumbnail")]
    public BingVideoThumbnail Thumbnail { get; set; }
    public string videoId { get; set; }
    public bool allowMobileEmbed { get; set; }
    public bool isSuperfresh { get; set; }
}

public class VideoPublisher
{
    [JsonProperty("name")]
    public string Name { get; set; }
}

public class VideoCreator
{
    [JsonProperty("name")]
    public string Name { get; set; }
}

public class BingVideoThumbnail
{
    public int width { get; set; }
    public int height { get; set; }
}

public class PivotSuggestions
{
    public string pivot { get; set; }
    public Suggestions[] suggestions { get; set; }
}

public class Suggestions
{
    public string text { get; set; }
    public string displayText { get; set; }
    public string webSearchUrl { get; set; }
    public string searchLink { get; set; }
    public Thumbnail1 thumbnail { get; set; }
}

public class Thumbnail1
{
    public string thumbnailUrl { get; set; }
}

public class VideoRelatedSearches
{
    public string text { get; set; }
    public string displayText { get; set; }
    public string webSearchUrl { get; set; }
    public string searchLink { get; set; }
    public Thumbnail2 thumbnail { get; set; }
}

public class Thumbnail2
{
    public string thumbnailUrl { get; set; }
}

