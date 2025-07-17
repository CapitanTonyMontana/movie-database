using movie_database;
class Program
{
    static void Main()
    {
        while (true)
        {
            Console.WriteLine("W BIBLIOTECE FIMLÓW");
            Console.WriteLine("\n\n=== MENU ===");
            Console.WriteLine("\n 1.Wyświetl wszystkie tytuły");
            Console.WriteLine("\n 9.Zakoncz program");
            string choose = Console.ReadLine();
            if (choose == "1")
            {
                MovieTitleViewer viewTitles = new MovieTitleViewer();
                viewTitles.ShowTitles();
            }
            else if (choose == "9")
            {
                Console.WriteLine("Zakończono.");
                break;
            }
            else
            {
                Console.WriteLine("Nieznana opcja. Spróbuj ponownie.");
            }
        }
    }
}                                                      