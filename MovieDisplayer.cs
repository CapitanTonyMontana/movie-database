namespace movie_database
{
    public class MovieDisplayer
    {
      public void PrintTitles(List<Movie> movies)
      {
            if (movies.Count == 0)
            {
                Console.WriteLine("Nie znaleziono tytułów.");
                return;
            }
            Console.WriteLine("Tytuły filmów: ");
            foreach (var movie in movies)
            {
                if (!string.IsNullOrWhiteSpace(movie.Title))
                    Console.WriteLine(" - " + movie.Title);
            }
      }
        public void ShowMatchingTitles(List<Movie> movies, string query)
        {
            var matching = movies
                .Where(m => m.Title != null && m.Title.Contains(query, StringComparison.OrdinalIgnoreCase))
                .ToList();
            if (matching.Count == 0)
            {
                Console.WriteLine($"Brak tytułów zawierających: \"{query}\"");
                return;
            }
            Console.WriteLine($"\nFilmy zawierające \"{query}\":");
            foreach (var movie in matching)
            {
                Console.WriteLine(" - " + movie.Title);
            }
        }
        public void ShowMoviesWithActor(List<Movie> movies, string actorName)
        {
            var matchingMovies = movies
                .Where(m => m.Actors != null && m.Actors
                    .Any(a => a.Contains(actorName, StringComparison.OrdinalIgnoreCase)))
                .ToList();
            if (matchingMovies.Count == 0)
            {
                Console.WriteLine($"Brak filmów z aktorem zawierającym: \"{actorName}\"");
                return;
            }
            Console.WriteLine($"\nFilmy z aktorem zawierającym: \"{actorName}\"");
            foreach (var movie in matchingMovies)
            {
                Console.WriteLine(" - " + movie.Title);
            }
        }
        public void ShowMoviesWithGenre(List<Movie> movies, string genreQuery)
        {
            var matching = movies
                .Where(m => !string.IsNullOrWhiteSpace(m.Genre) &&
                            m.Genre.Contains(genreQuery, StringComparison.OrdinalIgnoreCase))
                .ToList();
            if (matching.Count == 0)
            {
                Console.WriteLine($"Nie znaleziono filmów w gatunku zawierającym: \"{genreQuery}\"");
                return;
            }
            Console.WriteLine($"\nFilmy w gatunku zawierającym: \"{genreQuery}\":");
            foreach (var movie in matching)
            {
                Console.WriteLine(" - " + movie.Title);
            }
        }
        public void ShowMoviesFromYear(List<Movie> movies, int year)
        {
            var matching = movies
                .Where(m => m.Year == year)
                .ToList();
            if (matching.Count == 0)
            {
                Console.WriteLine($"Nie znaleziono filmów z roku: {year}");
                return;
            }
            Console.WriteLine($"\nFilmy z roku {year}:");
            foreach (var movie in matching)
            {
                Console.WriteLine(" - " + movie.Title);
            }
        }
    }
}
