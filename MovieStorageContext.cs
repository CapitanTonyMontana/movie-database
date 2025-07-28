namespace movie_database
{
    public class MovieStorageContext
    {
        private MovieStrategy _strategy;
        public MovieStorageContext(MovieStrategy strategy)
        {
            _strategy = strategy;
        }
        public void SetStrategy(MovieStrategy strategy)
        {
            _strategy = strategy;
        }
        public List<Movie> Load(string path) => _strategy.Load(path);
        public void Save(string path, List<Movie> movies) => _strategy.Save(path, movies);
        public void Append(string path, Movie movie) => _strategy.Append(path, movie);
        public void Delete(string path, string title) => _strategy.Delete(path, title);

    }
}
