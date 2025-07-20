namespace movie_database
{
    public class MovieDisplayer
    {
        private readonly Validator _validator = new Validator();
        public void PrintTitles(List<Movie> movies)
        {
            if (movies.Count == 0)
            {
                Printer.TitlesNotFound();
                return;
            }
            Printer.TitlesNames();
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
               Printer.NoTitlesContaining(query);
                return;
            }
            Printer.PhrasesContaining(query);
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
                Printer.NoMoviesFeaturingActor(actorName);
                return;
            }
            Printer.FeaturingActor(actorName);
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
                Printer.NoFoundedGenre(genreQuery);
                return;
            }
            Printer.ListOfFoundedGenre(genreQuery);
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
                Printer.NotFoundedMoviesYear(year);
                return;
            }
            Printer.FoundedMoviesYear(year);
            foreach (var movie in matching)
            {
                Console.WriteLine(" - " + movie.Title);
            }
        }
        public Movie GetMovieFromUser()
        {
            Printer.AddingNewMovie();
            var title = _validator.GetNonEmptyString("Tytuł: ");
            var year = _validator.GetValidYear("Rok: ");
            var genre = _validator.GetNonEmptyString("Gatunek: ");
            var director = _validator.GetNonEmptyString("Reżyser: ");
            var actors = _validator.GetActorList("Aktorzy (oddzieleni przecinkami): ");
            return new Movie
            {
                Title = title,
                Year = year,
                Genre = genre,
                Director = director,
                Actors = actors
            };
        }
    }
}
