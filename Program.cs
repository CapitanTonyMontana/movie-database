using movie_database;
using System.Text.Json.Nodes;
class Program
{
    static void Main()
    {
        bool running = true;
        var validator = new Validator();
        var displayer = new MovieDisplayer();
        var jsonStrategy = new JsonMovieStrategy();
        var xmlStrategy = new XmlMovieStrategy();
        var context = new MovieStorageContext(jsonStrategy); 
        var jsonPath = "filmy.json";
        var xmlPath = "filmy.xml";
        List<Movie> allMovies = new();
        allMovies.AddRange(jsonStrategy.Load(jsonPath));
        allMovies.AddRange(xmlStrategy.Load(xmlPath));
        while (running)
        {
            Printer.ENTER();
            Printer.MOVIELIBARY();
            Printer.MENU();
            Printer.ViewAllTitles();
            Printer.ViewAllPhrasesInMovies();
            Printer.ViewMoviesWithSpecificActor();
            Printer.ViewSpecificGenere();
            Printer.ViewYearOfProduction();
            Printer.AddNewMovieXMLorJSON();
            Printer.DeleteMovie();
            Printer.EditMovieData();
            Printer.END();
            Printer.ENTER();
            var choice = Console.ReadLine();
            switch (choice)
            {
                case "1":
                    Printer.ENTER();
                    displayer.PrintTitles(allMovies);
                    Printer.ENTER();
                    break;
                case "2":
                    Printer.ENTER();
                    var query = validator.GetNonEmptyString("Podaj tekst do wyszukania: ");
                    displayer.ShowMatchingTitles(allMovies, query);
                    Printer.ENTER();
                    break;
                case "3":
                    Printer.ENTER();
                    var actor = validator.GetNonEmptyString("Podaj imię lub nazwisko aktora: ");
                    displayer.ShowMoviesWithActor(allMovies, actor);
                    Printer.ENTER();
                    break;
                case "4":
                    Printer.ENTER();
                    var genre = validator.GetNonEmptyString("Podaj gatunek filmu: ");
                    displayer.ShowMoviesWithGenre(allMovies, genre);
                    Printer.ENTER();
                    break;
                case "5":
                    Printer.ENTER();
                    var year = validator.GetValidYear("Podaj rok: ");
                    displayer.ShowMoviesFromYear(allMovies, year);
                    Printer.ENTER();
                    break;
                case "6":
                    Printer.ENTER();
                    var addFormat = validator.GetFileFormat();
                    var newMovie = displayer.GetMovieFromUser();
                    context.SetStrategy(addFormat == "json" ? jsonStrategy : xmlStrategy);
                    context.Append(addFormat == "json" ? jsonPath : xmlPath, newMovie);
                    allMovies = jsonStrategy.Load(jsonPath);
                    allMovies.AddRange(xmlStrategy.Load(xmlPath));
                    Printer.ENTER();
                    break;
                case "7":
                    Printer.ENTER();
                    var deleteFormat = validator.GetFileFormat();
                    var titleToDelete = validator.GetNonEmptyString("Podaj tytuł filmu do usunięcia: ");
                    context.SetStrategy(deleteFormat == "json" ? jsonStrategy : xmlStrategy);
                    context.Delete(deleteFormat == "json" ? jsonPath : xmlPath, titleToDelete);
                    allMovies = jsonStrategy.Load(jsonPath);
                    allMovies.AddRange(xmlStrategy.Load(xmlPath));
                    Printer.ENTER();
                    break;
                case "8":
                    Printer.ENTER();
                    var editFormat = validator.GetFileFormat();
                    var titleToEdit = validator.GetNonEmptyString("Podaj tytuł filmu do edycji: ");
                    context.SetStrategy(editFormat == "json" ? jsonStrategy : xmlStrategy);
                    var editPath = editFormat == "json" ? jsonPath : xmlPath;
                    var moviesToEdit = context.Load(editPath);
                    var movieToEdit = moviesToEdit.FirstOrDefault(m => m.Title?.Equals(titleToEdit, StringComparison.OrdinalIgnoreCase) == true);
                    if (movieToEdit == null)
                    {
                        Printer.NoMovieWithTheGivenTitleFound();
                        Printer.ENTER();
                        break;
                    }
                    Printer.SetNewData();
                    var newTitle = validator.GetOptionalString("Nowy tytuł: ");
                    if (!string.IsNullOrWhiteSpace(newTitle))
                    {
                        movieToEdit.Title = newTitle;
                    }
                    var newYearInput = validator.GetOptionalString("Nowy rok: ");
                    if (int.TryParse(newYearInput, out int newYear))
                    {
                        movieToEdit.Year = newYear;
                    }
                    var newGenre = validator.GetOptionalString("Nowy gatunek: ");
                    if (!string.IsNullOrWhiteSpace(newGenre))
                    {
                        movieToEdit.Genre = newGenre;
                    }
                    var newDirector = validator.GetOptionalString("Nowy reżyser: ");
                    if (!string.IsNullOrWhiteSpace(newDirector))
                    {
                        movieToEdit.Director = newDirector;
                    }
                    var actorsInput = validator.GetOptionalString("Nowi aktorzy (oddzieleni przecinkami): ");
                    if (!string.IsNullOrWhiteSpace(actorsInput))
                    {
                        movieToEdit.Actors = actorsInput
                            .Split(',')
                            .Select(a => a.Trim())
                            .Where(a => !string.IsNullOrWhiteSpace(a))
                            .ToList();
                    }
                    context.Save(editPath, moviesToEdit);
                    allMovies = jsonStrategy.Load(jsonPath);
                    allMovies.AddRange(xmlStrategy.Load(xmlPath));
                    Printer.UpdatedData();
                    Printer.ENTER();
                    break;
                case "9":
                    Printer.ENTER();
                    running = false;
                    break;
                default:
                    Printer.UnknownOption();
                    Printer.ENTER();
                    break;
            }
        }
    }

}
    