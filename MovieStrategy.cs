namespace movie_database
{
    public interface MovieStrategy
    {
        List<Movie> Load(string path);
        void Save(string path, List<Movie> movies);
        void Append(string path, Movie movie);
        void Delete(string path, string title);

    }
}
