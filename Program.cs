using movie_database;
using System.Text.Json.Nodes;
class Program
{
    static void Main()
    {
        bool running = true;
        var loader = new MovieLibaryLoader();
        var displayer= new MovieDisplayer();
        var validator = new Validator();
        List<Movie> allMovies = new();
        allMovies.AddRange(loader.LoadFromJson("filmy.json"));
        allMovies.AddRange(loader.LoadFromXml("filmy.xml"));
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
                    int year = validator.GetValidYear("Podaj rok: ");
                    displayer.ShowMoviesFromYear(allMovies, year);
                    Printer.ENTER();
                    break;
                case "6":
                    Printer.ENTER();
                    var format = validator.GetFileFormat();
                    var newMovie = displayer.GetMovieFromUser();
                    if (format == "json")
                        loader.AppendToJson("filmy.json", newMovie);
                    else
                        loader.AppendToXml("filmy.xml", newMovie);
                    allMovies = loader.LoadFromJson("filmy.json");
                    allMovies.AddRange(loader.LoadFromXml("filmy.xml"));
                    Printer.ENTER();
                    break;

                case "7":
                    Printer.ENTER();
                    var deleteFormat = validator.GetFileFormat();
                    var titleToDelete = validator.GetNonEmptyString("Podaj tytuł filmu do usunięcia: ");
                    if (deleteFormat == "json")
                        loader.DeleteFromJson("filmy.json", titleToDelete);
                    else
                        loader.DeleteFromXml("filmy.xml", titleToDelete);
                    Printer.ENTER();
                    break;
                case "8":
                    Printer.ENTER();
                    var editFormat = validator.GetFileFormat();
                    var titleToEdit = validator.GetNonEmptyString("Podaj tytuł filmu do edycji: ");
                    var all = editFormat switch
                    {
                        "json" => loader.LoadFromJson("filmy.json"),
                        "xml" => loader.LoadFromXml("filmy.xml"),
                        _ => null
                    };
                    if (all == null)
                    {
                        Printer.InvalidFormat();
                        Printer.ENTER();
                        break;
                    }
                    var movieToEdit = all.FirstOrDefault(m => m.Title?.Equals(titleToEdit, StringComparison.OrdinalIgnoreCase) == true);
                    if (movieToEdit == null)
                    {
                        Printer.NoMovieWithTheGivenTitleFound()
                        Printer.ENTER();
                        break;
                    }
                    Console.WriteLine("Podaj nowe dane. Pozostaw puste, by zachować stare.");
                    var newTitle = validator.GetOptionalString("Nowy tytuł: ");
                    if (!string.IsNullOrWhiteSpace(newTitle)) movieToEdit.Title = newTitle;
                    var newYearInput = validator.GetOptionalString("Nowy rok: ");
                    if (int.TryParse(newYearInput, out int newYear)) movieToEdit.Year = newYear;
                    var newGenre = validator.GetOptionalString("Nowy gatunek: ");
                    if (!string.IsNullOrWhiteSpace(newGenre)) movieToEdit.Genre = newGenre;
                    var newDirector = validator.GetOptionalString("Nowy reżyser: ");
                    if (!string.IsNullOrWhiteSpace(newDirector)) movieToEdit.Director = newDirector;
                    var actorsInput = validator.GetOptionalString("Nowi aktorzy (oddzieleni przecinkami): ");
                    if (!string.IsNullOrWhiteSpace(actorsInput))
                        movieToEdit.Actors = actorsInput.Split(',').Select(a => a.Trim()).ToList();
                    if (editFormat == "json")
                        loader.SaveToJson("filmy.json", all);
                    else
                        loader.SaveToXml("filmy.xml", all);
                    Printer.UpdatedData();
                    allMovies = loader.LoadFromJson("filmy.json");
                    allMovies.AddRange(loader.LoadFromXml("filmy.xml"));
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