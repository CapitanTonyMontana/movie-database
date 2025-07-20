namespace movie_database
{
    using System.Collections.Generic;
    using System.Xml.Serialization;

    [XmlRoot("Movies")]
    public class MovieCollection
    {
        [XmlElement("Movie")]
        public List<Movie> Items { get; set; }
    }


}
