namespace MovieDb.Models;

public class SearchViewModel
{
    public List<MoviesThumb> searchList;
    public string title;

    public Dictionary<int, string> genreDict;
}