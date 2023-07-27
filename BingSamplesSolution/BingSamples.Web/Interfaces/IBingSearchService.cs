using BingSamples.Web.Core;
using BingSamples.Web.Models;

namespace BingSamples.Web.Interfaces;

public interface IBingSearchService
{
    Task<PaginatedList<SearchModel>> SearchAsync(int page, int pageCount, string query);
}