
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
        [RegularExpression(@"[0-9a-zA-ZøæåØÆÅ\\-. ]{2,30}")]
        public string Duration { get; set; }
        [RegularExpression(@"[0-9]{1,2}\/[0-9]{1,2}\/[0-9]{4}")]
        public string Dateposted { get; set; }
        [RegularExpression(@"[0-9a-zA-ZøæåØÆÅ\\-. ]{2,30}")]
        public string Datetime { get; set; }
        [RegularExpression(@"[0-9a-zA-ZøæåØÆÅ\\-. ]{2,500}")]
        public string Comments { get; set; }
    }   
}
