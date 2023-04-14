namespace MovieDb.Models;

public class Genre
{
    public int id { get; set; }
    public string name { get; set; }

    public override string ToString()
    {
        return $"id: {id} name: {name}";
    }
}
public class Movie
{
    private string _backdrop_path;
    public string backdrop_path
    {
        get { return this._backdrop_path; }
        set
        {
            if (String.IsNullOrEmpty(value))
            {
                this._backdrop_path = "https://upload.wikimedia.org/wikipedia/commons/6/64/Poster_not_available.jpg";
            }
            else
            {
                this._backdrop_path = "https://image.tmdb.org/t/p/w1280" + value;
            }

        }
    }
    public int budget { get; set; }

    public List<Genre> genres { get; set; }
    public int id { get; set; }

    public string title { get; set; }
    public string original_title { get; set; }

    public string overview { get; set; }

    public double vote_average { get; set; }
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

    public string release_date { get; set; }
    public long revenue { get; set; }
    public int? runtime { get; set; }

    public override string ToString()
    {
        return $"id: {id} title: {original_title} release date: {release_date} backdrop path: {backdrop_path} budget: {budget} revenue: {revenue} genre: {String.Join(",", genres)}";

    }
}