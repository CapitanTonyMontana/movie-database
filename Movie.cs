using System.Xml.Serialization;
namespace movie_database
{
    public class Movie
    {
            public string Title { get; set; }
            public int Year { get; set; }
            public string Genre { get; set; }
            public string Director { get; set; }

        [XmlArray("Actors")]
        [XmlArrayItem("Actor")]
        public List<string> Actors { get; set; }
    }
    
}
