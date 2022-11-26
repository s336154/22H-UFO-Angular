
using UFO_Webapplikasjon.Model;

namespace UFO_Webapplikasjon.DAL
{
    public interface InSightingRepository
    {
        Task<bool> Create(Sighting innSighting);
        Task<List<Sighting>> ReadAll();
        Task<List<Sighting>> ReadIdDesc();
        Task<List<Sighting>> ReadCountryAsc();
        Task<List<Sighting>> ReadCountryDesc();
        Task<List<Sighting>> ReadCityAsc();
        Task<List<Sighting>> ReadCityDesc();
        Task<Sighting> ReadLatest();
        Task<bool> Delete(int id);
        Task<Sighting> ReadOne(int id);
        Task<bool> Update(Sighting updateSighting);
    }
}
