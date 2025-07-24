namespace movie_database
{
    public class Printer
    {
        public static void ValueCannotBeEmpty()
        {
            Console.WriteLine("Wartość nie może być pusta.");
        }

        public static void SelectFormatJsonXML()
        {
            Console.Write("Wybierz format (json/xml): ");
        }
        public static void InvalidFormat()
        {
            Console.WriteLine("Nieprawidłowy format. Spróbuj ponownie.");
        }
        public static void InvalidYearFormat()
        {
            Console.WriteLine("Niepoprawny format. Wprowadź rok jako liczbę.");
        }
        public static void TitlesNotFound()
        {
            Console.WriteLine("Nie znaleziono tytułów.");
        }
        public static void TitlesNames()
        {
            Console.WriteLine("Tytuły filmów: ");
        }
        public static void NoTitlesContaining(string query)
        {
            Console.WriteLine($"Brak tytułów zawierających: \"{query}\"");
        }

        public static void PhrasesContaining(string query)
        {
            Console.WriteLine($"\nFilmy zawierające \"{query}\":");
        }

        public static void NoMoviesFeaturingActor(string actorName)
        {
            Console.WriteLine($"Brak filmów z aktorem zawierającym: \"{actorName}\"");
        }
        public static void FeaturingActor(string actorName)
        {
            Console.WriteLine($"\nFilmy z aktorem zawierającym: \"{actorName}\"");
        }
        public static void NoFoundedGenre(string genreQuery)
        {
            Console.WriteLine($"Nie znaleziono filmów w gatunku: \"{genreQuery}\"");
        }
        public static void ListOfFoundedGenre(string genreQuery)
        {
            Console.WriteLine($"\nFilmy w gatunku: \"{genreQuery}\":");
        }
        public static void NotFoundedMoviesYear(int year)
        {
            Console.WriteLine($"Nie znaleziono filmów z roku: {year}");
        }
        public static void FoundedMoviesYear(int year)
        {
            Console.WriteLine($"\nFilmy z roku {year}:");
        }
        public static void AddingNewMovie()
        {
            Console.WriteLine("Dodawanie nowego filmu:");
        }

        public static void MovieNotFound()
        {
            Console.WriteLine("Nie znaleziono filmu o podanym tytule.");
        }

        public static void DeletedFromJson()
        {
            Console.WriteLine("Film został usunięty z pliku JSON.");
        }
        public static void DeletedFromXML()
        {
            Console.WriteLine("Film został usunięty z pliku XML.");
        }
        public static void ENTER()
        {
            Console.WriteLine();
        }
        public static void MOVIELIBARY()
        {
            Console.WriteLine("W BIBLIOTECE FIMLÓW");
        }
        public static void MENU()
        {
            Console.WriteLine("\n\n=== MENU ===");
        }
        public static void ViewAllTitles()
        {
            Console.WriteLine("1.Wyświetl wszystkie tytuły");
        }
        public static void ViewAllPhrasesInMovies()
        {
            Console.WriteLine("2.Wyswietl wszystkie filmy zawierające dany tekst");
        }
        public static void ViewMoviesWithSpecificActor()
        {
            Console.WriteLine("3.Filmy z danym aktorem");
        }
        public static void ViewSpecificGenere()
        {
            Console.WriteLine("4.Wyświetl wszystkie filmy danego gatunku");
        }
        public static void ViewYearOfProduction()
        {
            Console.WriteLine("5.Wyświetl wszystkie filmy z danego roku");
        }
        public static void AddNewMovieXMLorJSON()
        {
            Console.WriteLine("6.Dodaj nowy film (do JSON lub XML)");
        }
        public static void DeleteMovie()
        {
            Console.WriteLine("7.Usuń film");
        }
        public static void EditMovieData()
        {
            Console.WriteLine("8.Edytuj dane filmu");
        }
        public static void END()
        {
            Console.WriteLine("9.Zakoncz program");
        }
        public static void NoMovieWithTheGivenTitleFound()
        {
            Console.WriteLine("Nie znaleziono filmu o podanym tytule.");
        }
        public static void UpdatedData()
        {
            Console.WriteLine("Film został zaktualizowany.");
        }
        public static void UnknownOption()
        {
            Console.WriteLine("Nieznana opcja. Spróbuj ponownie.");
        }
        public static void SetNewData()
        {
            Console.WriteLine("Podaj nowe dane. Pozostaw puste, by zachować stare.");
        }
    }
}
