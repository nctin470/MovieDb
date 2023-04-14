namespace MovieDb.Models;

public class ImageModel
{
    private string _file_path;
    public string file_path
    {
        get
        {
            return this._file_path;
        }
        set
        {
            this._file_path = "https://image.tmdb.org/t/p/original" + value;
        }
    }

}