namespace MovieDb.Models;

public class CastThumb
{

    public long id { get; set; }
    public string name { get; set; }
    private string _profile_path;

    public string profile_path
    {
        get
        {
            return this._profile_path;
        }
        set
        {
            if (String.IsNullOrEmpty(value))
            {
                this._profile_path = "https://upload.wikimedia.org/wikipedia/commons/6/64/Poster_not_available.jpg";
            }
            else
            {
                this._profile_path = "https://image.tmdb.org/t/p/w500/" + value;
            }
        }
    }

    public string character { get; set; }

    public override string ToString()
    {
        return $"id {id} name {name} character {character} profile_path {profile_path}";
    }
}