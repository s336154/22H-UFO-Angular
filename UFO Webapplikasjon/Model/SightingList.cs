namespace UFO_Webapplikasjon.Model
{
    public class SightingList
    {
        public int Id { get; set; }
        public virtual User User { get; set; }
        public virtual Sighting Sighting { get; set; }

        // Is a list of Sightings written like this?
        // public virtual List<Sighting> Sighting { get; set; }
    }
}
