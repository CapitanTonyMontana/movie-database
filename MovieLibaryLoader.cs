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
        public void AppendToJson(string path, Movie newMovie)
        {
            List<Movie> movies = new();
            if (File.Exists(path))
            {
                var json = File.ReadAllText(path);
                movies = JsonSerializer.Deserialize<List<Movie>>(json) ?? new();
            }
            movies.Add(newMovie);
            var updatedJson = JsonSerializer.Serialize(movies, new JsonSerializerOptions { WriteIndented = true });
            File.WriteAllText(path, updatedJson);
        }
        public void AppendToXml(string path, Movie newMovie)
        {
            MovieCollection collection = new();
            if (File.Exists(path))
            {
                using var fs = new FileStream(path, FileMode.Open);
                var serializer = new XmlSerializer(typeof(MovieCollection));
                collection = (MovieCollection?)serializer.Deserialize(fs) ?? new();
            }
            collection.Items ??= new List<Movie>();
            collection.Items.Add(newMovie);
            using var writer = new FileStream(path, FileMode.Create);
            var newSerializer = new XmlSerializer(typeof(MovieCollection));
            newSerializer.Serialize(writer, collection);
        }
        public void DeleteFromJson(string path, string title)
        {
            var movies = LoadFromJson(path);
            var updated = movies.Where(m => !string.Equals(m.Title, title, StringComparison.OrdinalIgnoreCase)).ToList();

            if (updated.Count == movies.Count)
            {
                Printer.MovieNotFound();
                return;
            }

            string json = JsonSerializer.Serialize(updated, new JsonSerializerOptions { WriteIndented = true });
            File.WriteAllText(path, json);
            Printer.DeletedFromJson();
        }
        public void DeleteFromXml(string path, string title)
        {
            var movies = LoadFromXml(path);
            var updated = movies.Where(m => !string.Equals(m.Title, title, StringComparison.OrdinalIgnoreCase)).ToList();
            if (updated.Count == movies.Count)
            {
                Printer.MovieNotFound();
                return;
            }
            var movieCollection = new MovieCollection { Items = updated };
            XmlSerializer serializer = new XmlSerializer(typeof(MovieCollection));
            using FileStream fs = new FileStream(path, FileMode.Create);
            serializer.Serialize(fs, movieCollection);
            Printer.DeletedFromXML();
        }
        public void SaveToJson(string path, List<Movie> movies)
        {
            var json = JsonSerializer.Serialize(movies, new JsonSerializerOptions { WriteIndented = true });
            File.WriteAllText(path, json);
        }
        public void SaveToXml(string path, List<Movie> movies)
        {
            var collection = new MovieCollection { Items = movies };
            XmlSerializer serializer = new XmlSerializer(typeof(MovieCollection));
            using FileStream fs = new FileStream(path, FileMode.Create);
            serializer.Serialize(fs, collection);
        }
    }
}
