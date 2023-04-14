namespace MovieDb.Models;

public class MoviesThumb
{
    private string _poster_path;
    public string poster_path
    {
        get { return this._poster_path; }
        set
        {
            if (String.IsNullOrEmpty(value))
            {
                this._poster_path = "https://upload.wikimedia.org/wikipedia/commons/6/64/Poster_not_available.jpg";
            }
            else
            {
                this._poster_path = "https://image.tmdb.org/t/p/w500" + value;
            }

        }
    }
    public string overview { get; set; }
    public string release_date { get; set; }
    public int id { get; set; }
    public string original_title { get; set; }
    public string original_language { get; set; }
    public string title { get; set; }

    public int[] genre_ids { get; set; }

    public double vote_average { get; set; }

    public override string ToString()
    {
        return $"id: {id} title: {title} release date: {release_date} poster path: {poster_path} genre_ids: {String.Join(",", Array.ConvertAll(genre_ids, x => x.ToString()))}";
    }

}