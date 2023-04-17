using MovieDb.Models;
using Newtonsoft.Json.Linq;

namespace MovieDb.logic;

public interface IMovieFetcher
{
    Task<List<CastThumb>> fetchCast(int movie_id);
    Task<Movie> fetchMovieDetails(int movie_id);
    Task<List<ImageModel>> fetchImages(int movie_id);

    Task<List<MoviesThumb>> searchMovie(String query);
}

public class MovieFetcher : IMovieFetcher
{
    private readonly IConfiguration _configuration;
    public MovieFetcher(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    public async Task<Movie> fetchMovieDetails(int movie_id)
    {
        var api_key = _configuration.GetValue("API_KEY", "");
        string url = $"https://api.themoviedb.org/3/movie/{movie_id}?api_key={api_key}&language=en-US";
        using (var httpClient = new HttpClient())
        {
            using (var response = await httpClient.GetAsync(url))
            {
                string apiResponse = await response.Content.ReadAsStringAsync();
                return JObject.Parse(apiResponse).ToObject<Movie>();

            }
        }
    }

    public async Task<List<CastThumb>> fetchCast(int movie_id)
    {
        var api_key = _configuration.GetValue("API_KEY", "");
        string url = $"https://api.themoviedb.org/3/movie/{movie_id}/credits?api_key={api_key}&language=en-US";
        using (var httpClient = new HttpClient())
        {
            using (var response = await httpClient.GetAsync(url))
            {
                string apiResponse = await response.Content.ReadAsStringAsync();
                return JObject.Parse(apiResponse)["cast"].ToObject<List<CastThumb>>();
            }
        }
    }

    public async Task<List<ImageModel>> fetchImages(int movie_id)
    {
        var api_key = _configuration.GetValue("API_KEY", "");
        string url = $"https://api.themoviedb.org/3/movie/{movie_id}/images?api_key={api_key}";
        using (var httpClient = new HttpClient())
        {
            using (var response = await httpClient.GetAsync(url))
            {
                string apiResponse = await response.Content.ReadAsStringAsync();
                return JObject.Parse(apiResponse)["backdrops"].ToObject<List<ImageModel>>();
            }
        }
    }

    public async Task<List<MoviesThumb>> searchMovie(String query)
    {
        var api_key = _configuration.GetValue("API_KEY", "");
        string url = $"https://api.themoviedb.org/3/search/movie?api_key={api_key}&language=en-US&query={query}&page=1&include_adult=false";
        using (var httpClient = new HttpClient())
        {
            using (var response = await httpClient.GetAsync(url))
            {
                string apiResponse = await response.Content.ReadAsStringAsync();
                return JObject.Parse(apiResponse)["results"].ToObject<List<MoviesThumb>>();
            }
        }
    }
}