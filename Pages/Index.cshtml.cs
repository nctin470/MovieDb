using Newtonsoft.Json;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MovieDb.Models;
using Newtonsoft.Json.Linq;
using MovieDb.logic;
using Microsoft.AspNetCore.Mvc;

namespace MovieDb.Pages;
[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
public class IndexModel : PageModel
{
    private readonly ILogger<IndexModel> _logger;
    private readonly IConfiguration _configuration;
    private readonly IGenreFetcher _fetcher;

    public List<MoviesThumb> movieList;
    public int CurrentPage;
    public int TotalPages;

    public Dictionary<int, string> genreDict;

    public IndexModel(ILogger<IndexModel> logger, IConfiguration configuration, IGenreFetcher genrefetcher)
    {
        _logger = logger;
        _configuration = configuration;
        _fetcher = genrefetcher;
        movieList = new List<MoviesThumb>();
    }

    public async Task OnGetAsync(int? pageIndex)
    {
        if (pageIndex != null)
        {
            CurrentPage = (int)pageIndex;
        }
        else
        {
            CurrentPage = 1;
        }

        var api_key = _configuration.GetValue("API_KEY", "");
        if (_fetcher.genre_dict.Count == 0)
        {
            await _fetcher.FetchGenre($"https://api.themoviedb.org/3/genre/movie/list?api_key={api_key}&language=en-US");
        }
        genreDict = _fetcher.genre_dict;
        using (var httpClient = new HttpClient())
        {
            using (var response = await httpClient.GetAsync($"https://api.themoviedb.org/3/trending/movie/day?api_key={api_key}&page={CurrentPage}"))
            {
                string apiResponse = await response.Content.ReadAsStringAsync();

                TotalPages = JObject.Parse(apiResponse)["total_pages"].ToObject<int>();
                movieList = JObject.Parse(apiResponse)["results"].ToObject<List<MoviesThumb>>();
                /*
                foreach (var movie in movieList)
                {
                    Console.WriteLine(movie);

                }
                */
            }
        }
    }

    public void OnGetLoadMore()
    {
        Console.WriteLine("Loading More");
    }
}
