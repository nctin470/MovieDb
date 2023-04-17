using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MovieDb.logic;
using MovieDb.Models;

namespace MovieDb.Pages;

[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
public class SearchModel : PageModel
{
    private readonly ILogger<SearchModel> _logger;
    private readonly IMovieFetcher _fetcher;
    private readonly IGenreFetcher _genreFetcher;


    public SearchModel(ILogger<SearchModel> logger, IMovieFetcher fetcher, IGenreFetcher genreFetcher)
    {
        _logger = logger;
        _fetcher = fetcher;
        _genreFetcher = genreFetcher;
    }

    public List<MoviesThumb> resultList;


    public async Task<PartialViewResult> OnGetSearch(string searchTerm)
    {
        Console.WriteLine("Search handler on get reached");
        ViewData["SearchTitle"] = "Search Results for " + searchTerm;
        resultList = await _fetcher.searchMovie(searchTerm);
        var vmodel = new SearchViewModel { searchList = resultList, title = searchTerm, genreDict = _genreFetcher.genre_dict };
        return Partial("_SearchResults", vmodel);
    }
}

