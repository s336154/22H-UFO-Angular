namespace UFO_Webapplikasjon.Controllers
{
    public class ControllerExtra
    {
        /*
         
        using UFO_Webapplikasjon.DAL;
using UFO_Webapplikasjon.Model;
using Microsoft.AspNetCore.Mvc;

namespace UFO_Webapplikasjon.Controllers
{
    [ApiController]
    // dekoratøren over må være med; dersom ikke må post og put bruke [FromBody] som deoratør inne i prameterlisten
    [Route("api/[controller]")]
    public class SightingController : ControllerBase
    {
        private readonly InSightingRepository _db;

        private ILogger<SightingController> _log;


        public SightingController(InSightingRepository db, ILogger<SightingController> log)
        {
            {
            _db = db;
             _log = log;
            }

        [HttpPost]
        public async Task<ActionResult> Create(Sighting innSighting)
        {
            return await _db.Create(innSighting);
        }

        public async Task<List<Sighting>> ReadAll()
        {
            return await _db.ReadAll();
        }
        
        public async Task<List<Sighting>> ReadIdDesc()
        {
            return await _db.ReadIdDesc();
        }
        public async Task<List<Sighting>> ReadCountryAsc()
        {
            return await _db.ReadCountryAsc();
        }
        public async Task<List<Sighting>> ReadCountryDesc()
        {
            return await _db.ReadCountryDesc();
        }
        public async Task<List<Sighting>> ReadCityAsc()
        {
            return await _db.ReadCityAsc();
        }
        public async Task<List<Sighting>> ReadCityDesc()
        {
            return await _db.ReadCityDesc();
        }

        public async Task<bool> Delete(int id)
        {
            return await _db.Delete(id);
        }

        public async Task<Sighting> ReadLatest()
        {
            return await _db.ReadLatest();
        }

        public async Task<Sighting> ReadOne(int id)
        {
            return await _db.ReadOne(id);
        }

        public async Task<bool> Update(Sighting updateSighting)
        {
            return await _db.Update(updateSighting);
        }
    }
}

         */

    }
}
