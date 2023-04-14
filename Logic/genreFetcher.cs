using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace MovieDb.logic;

public interface IGenreFetcher
{
    Dictionary<int, string> genre_dict { get; set; }

    Task FetchGenre(string url);
}

public class Genre
{
    public int id { get; set; }
    public string name { get; set; }
}

public class GenreFetcher : IGenreFetcher
{

    public Dictionary<int, string> genre_dict { get; set; }
    public GenreFetcher()
    {
        genre_dict = new Dictionary<int, string>();
    }

    public async Task FetchGenre(string url)
    {
        using (var httpClient = new HttpClient())
        {
            using (var response = await httpClient.GetAsync(url))
            {
                string apiResponse = await response.Content.ReadAsStringAsync();
                var jTokens = JObject.Parse(apiResponse)["genres"].Children();
                genre_dict = jTokens.Select(token => new KeyValuePair<int, string>((int)token["id"], (string)token["name"])).ToDictionary(pair => pair.Key, pair => pair.Value);
            }
        }
        Console.WriteLine($"genre dict has {genre_dict.Count}");
    }
}


