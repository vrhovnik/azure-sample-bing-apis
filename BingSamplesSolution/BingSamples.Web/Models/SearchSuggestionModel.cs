namespace BingSamples.Web.Models;

public class SearchSuggestionModel
{
    public string Title { get; set; }
    public List<SearchSuggestionDetail> Details { get; set; }
}

public record SearchSuggestionDetail(string Name,string Url);