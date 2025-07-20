using System.Text.Json;
using System.Xml.Serialization;

namespace movie_database
{
    public class MovieLibaryLoader
    {
        public List<Movie> LoadFromJson(string path)
        {
            if (!File.Exists(path)) return new List<Movie>();
            var json = File.ReadAllText(path);
            return JsonSerializer.Deserialize<List<Movie>>(json) ?? new List<Movie>();
        }

        public List<Movie> LoadFromXml(string path)
        {
            if (!File.Exists(path)) return new List<Movie>();
            XmlSerializer serializer = new XmlSerializer(typeof(MovieCollection));
            using FileStream fs = new FileStream(path, FileMode.Open);
            var movies = (MovieCollection)serializer.Deserialize(fs);
            return movies?.Items ?? new List<Movie>();
        }

    }
}
