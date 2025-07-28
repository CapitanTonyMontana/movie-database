using System.Xml.Serialization;

namespace movie_database
{
    public class XmlMovieStrategy : MovieStrategy
    {
        public List<Movie> Load(string path)
        {
            if (!File.Exists(path)) return new();
            var serializer = new XmlSerializer(typeof(MovieCollection));
            using var fs = new FileStream(path, FileMode.Open);
            var collection = (MovieCollection)serializer.Deserialize(fs);
            return collection?.Items ?? new();
        }
        public void Save(string path, List<Movie> movies)
        {
            var collection = new MovieCollection { Items = movies };
            var serializer = new XmlSerializer(typeof(MovieCollection));
            using var fs = new FileStream(path, FileMode.Create);
            serializer.Serialize(fs, collection);
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
            Printer.DeletedFromXML();
        }
    }
}
