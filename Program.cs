using movie_database;
class Program
{
    static void Main()
    {
        bool running = true;
        var loader = new MovieLibaryLoader();
        var displayer= new MovieDisplayer();
        List<Movie> allMovies = new();
        allMovies.AddRange(loader.LoadFromJson("filmy.json"));
        allMovies.AddRange(loader.LoadFromXml("filmy.xml"));
        while (running)
            
        {
            Console.WriteLine("W BIBLIOTECE FIMLÓW");
            Console.WriteLine("\n\n=== MENU ===");
            Console.WriteLine("1.Wyświetl wszystkie tytuły");
            Console.WriteLine("2.Wyswietl wszystkie filmy zawierające dany tekst");
            Console.WriteLine("3.Filmy z danym aktorem");
            Console.WriteLine("4.Wyświetl wszystkie filmy danego gatunku");
            Console.WriteLine("5.Wyświetl wszystkie filmy z danego roku");
            Console.WriteLine("9.Zakoncz program");
            var choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    displayer.PrintTitles(allMovies);
                    break;
                case "2":
                    Console.Write("Podaj tekst do wyszukania: ");
                    var query = Console.ReadLine();
                    displayer.ShowMatchingTitles(allMovies, query);
                    break;
                case "3":
                    Console.Write("Podaj imię lub nazwisko aktora: ");
                    var actor = Console.ReadLine();
                    displayer.ShowMoviesWithActor(allMovies, actor);
                    break;
                case "4":
                    Console.Write("Podaj gatunek filmu: ");
                    var genre = Console.ReadLine();
                    displayer.ShowMoviesWithGenre(allMovies, genre);
                    break;
                case "5":
                    Console.Write("Podaj rok: ");
                    if (int.TryParse(Console.ReadLine(), out int year))
                    {
                        displayer.ShowMoviesFromYear(allMovies, year);
                    }
                    else
                    {
                        Console.WriteLine("Niepoprawny format roku.");
                    }
                    break;
                case "9":
                    running = false;
                    break;
                default:
                    Console.WriteLine("Nieznana opcja. Spróbuj ponownie.");
                    break;
            }
        }
    }
}                                                      