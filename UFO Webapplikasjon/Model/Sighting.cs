
using System.ComponentModel.DataAnnotations;

namespace UFO_Webapplikasjon.Model
{
    public class Sighting
    {
        // med Id som variabel blir dette en autoincrement i databasen (pr. default).
        public int Id { get; set; }

        [RegularExpression(@"[a-zA-ZæøåÆØÅ. \-]{2,20}")]
        public string City { get; set; }

        [RegularExpression(@"[a-zA-ZæøåÆØÅ. \-]{2,20}")]
        public string Country { get; set; }
        public string Duration { get; set; }
        public string Dateposted { get; set; }
        public string Datetime { get; set; }
        public string Comments { get; set; }
    }   
}
