using Newtonsoft.Json;

namespace BingSamples.Web.Models;

public class BingNewsResponse
{
    public string _type { get; set; }
    public string readLink { get; set; }
    [JsonProperty("queryContext")]
    public NewsQueryContext QueryContext { get; set; }
    public int totalEstimatedMatches { get; set; }
    public Sort[] sort { get; set; }
    [JsonProperty("value")]
    public NewsDetail[] News { get; set; }
}

public class NewsQueryContext
{
    public string originalQuery { get; set; }
    public bool adultIntent { get; set; }
}

public class Sort
{
    public string name { get; set; }
    public string id { get; set; }
    public bool isSelected { get; set; }
    public string url { get; set; }
}

public class NewsDetail
{
    [JsonProperty("name")]
    public string Name { get; set; }
    [JsonProperty("url")]
    public string Url { get; set; }
    [JsonProperty("image")]
    public NewsImage Image { get; set; }
    [JsonProperty("description")]
    public string Description { get; set; }
    //public Provider[] provider { get; set; }
    [JsonProperty("datePublished")]
    public string DatePublished { get; set; }
    //public About[] about { get; set; }
}

public class NewsImage
{
    [JsonProperty("thumbnail")]
    public NewsImageThumbnail Thumbnail { get; set; }
}

public class NewsImageThumbnail
{
    public string contentUrl { get; set; }
    public int width { get; set; }
    public int height { get; set; }
}

// public class Provider
// {
//     public string _type { get; set; }
//     public string name { get; set; }
//     public Image1 image { get; set; }
// }
//
// public class Image1
// {
//     public Thumbnail1 thumbnail { get; set; }
// }
//
// public class Thumbnail1
// {
//     public string contentUrl { get; set; }
// }
//
// public class About
// {
//     public string readLink { get; set; }
//     public string name { get; set; }
// }

