using System.Text.Json;

namespace movie_database
{
    public class JsonMovieStrategy : MovieStrategy
    {
        public List<Movie> Load(string path)
        {
            if (!File.Exists(path)) return new();
            var json = File.ReadAllText(path);
            return JsonSerializer.Deserialize<List<Movie>>(json) ?? new();
        }
        public void Save(string path, List<Movie> movies)
        {
            var json = JsonSerializer.Serialize(movies, new JsonSerializerOptions { WriteIndented = true });
            File.WriteAllText(path, json);
        }
        public void Append(string path, Movie movie)
        {
            var movies = Load(path);
            movies.Add(movie);
            Save(path, movies);
        }
        public void Delete(string path, string title)
        {
            var movies = Load(path);
            var updated = movies.Where(m => !string.Equals(m.Title, title, StringComparison.OrdinalIgnoreCase)).ToList();
            Save(path, updated);
            Printer.DeletedFromJson();
        }

    }
}
