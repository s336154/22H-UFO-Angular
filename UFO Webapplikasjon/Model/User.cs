using System.ComponentModel.DataAnnotations;

namespace UFO_Webapplikasjon.Model
{
    public class User
    {
        public int Id { get; set; }

        [RegularExpression(@"^[a-zA-ZæøåÆØÅ. \-]{2,20}$")]
        public string Username { get; set; }

        [RegularExpression(@"^(?=.*[A-Za-z])(?=.*\d)[A-Za-z\d]{6,}$")]
        public string Password { get; set; }

        [RegularExpression(@"[a-zA-ZæøåÆØÅ. \-]{2,20}")]
        public string Firstname { get; set; }

        [RegularExpression(@"[a-zA-ZæøåÆØÅ. \-]{2,20}")]
        public string Lastname { get; set; }

        //list of sightings belonging to this person (i dont think its written like this?)
        public virtual List<SightingList> SightingList { get; set; }
        // public virtual List<Sighting> SightingList { get; set; }
    }
}