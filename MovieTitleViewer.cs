using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace movie_database
{
    internal class MovieTitleViewer
    {
        public void ShowTitles()
        {
            List<string> allTitles = new List<string>();
            string jsonPath = "filmy.json";
            if (File.Exists(jsonPath))
            {
                string json = File.ReadAllText(jsonPath);
                var jsonFilms = JsonSerializer.Deserialize<List<Movie>>(json);
                if (jsonFilms != null)
                {
                    foreach (var film in jsonFilms)
                    {
                        if (!string.IsNullOrWhiteSpace(film.Title))
                            allTitles.Add(film.Title);
                    }
                }
            }
            string xmlPath = "filmy.xml";
            if (File.Exists(xmlPath))
            {
                XmlSerializer serializer = new XmlSerializer(typeof(MovieCollection));
                using (FileStream fs = new FileStream(xmlPath, FileMode.Open))
                {
                    var movies = (MovieCollection)serializer.Deserialize(fs);
                    if (movies?.MovieList != null)
                    {
                        foreach (var film in movies.MovieList)
                        {
                            if (!string.IsNullOrWhiteSpace(film.Title))
                                allTitles.Add(film.Title);
                        }
                    }
                }
            }
            if (allTitles.Count == 0)
            {
                Console.WriteLine("Brak tytułów do wyświetlenia.");
            }
            else
            {
                Console.WriteLine("\nTytuły filmów:");
                foreach (var title in allTitles)
                {
                    Console.WriteLine(" - " + title);
                }
            }
        }
    }
}

