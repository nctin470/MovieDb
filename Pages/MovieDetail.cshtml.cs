using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MovieDb.logic;
using MovieDb.Models;

namespace MovieDb.Pages;

public class MovieDetailModel : PageModel
{
    private readonly ILogger<PrivacyModel> _logger;
    private readonly IConfiguration _configuration;
    private readonly IMovieFetcher _fetcher;

    public MovieDetailModel(ILogger<PrivacyModel> logger, IConfiguration configuration, IMovieFetcher fetcher)
    {
        _logger = logger;
        _configuration = configuration;
        _fetcher = fetcher;
    }

    public int movie_id;
    public Movie movie;
    public List<CastThumb> castList;
    public List<ImageModel> imageList;

    public async Task OnGetAsync(int id)
    {
        movie_id = id;
        movie = await _fetcher.fetchMovieDetails(id);
        castList = await _fetcher.fetchCast(id);
        imageList = await _fetcher.fetchImages(id);
    }
}

