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
            _db = db;
            _log = log;
        }

        [HttpGet]
        public async Task<ActionResult> ReadAll()
        {
            List<Sighting> everySightings = await _db.ReadAll();
            return Ok(everySightings);
        }

        [HttpGet]
        public async Task<ActionResult> ReadIdDesc()
        {
            List<Sighting> everySightings = await _db.ReadIdDesc();
            return Ok(everySightings);
        }

        [HttpGet]
        public async Task<ActionResult> ReadCountryAsc()
        {
            List<Sighting> everySightings = await _db.ReadCountryAsc();
            return Ok(everySightings);
        }

        [HttpGet]
        public async Task<ActionResult> ReadCountryDesc()
        {
            List<Sighting> everySightings = await _db.ReadCountryDesc();
            return Ok(everySightings);
        }

        [HttpGet]
        public async Task<ActionResult> ReadCityAsc()
        {
            List<Sighting> everySightings = await _db.ReadCityAsc();
            return Ok(everySightings);
        }

        [HttpGet]
        public async Task<ActionResult> ReadCityDesc()
        {
            List<Sighting> everySightings = await _db.ReadCityDesc();
            return Ok(everySightings);
        }


        [HttpPost]
        public async Task<ActionResult> Create(Sighting innSighting)
        {
            bool returOK = await _db.Create(innSighting);

            if (!returOK)
            {
                _log.LogInformation("The sighting could not be created.");
                return BadRequest("The sighting could not be saved.");
            }
            return Ok("The sighting is now created.");
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            bool returOK = await _db.Delete(id);

            if (!returOK)
            {
                _log.LogInformation("The sighting could not be deleted.");
                return NotFound("The sighting could not be deleted.");
            }
            return Ok("The sighting is now deleted.");
        }


        [HttpPost]
        public async Task<ActionResult> ReadLatest()
        {
            Sighting singleSighting = await _db.ReadLatest();

            if (singleSighting == null)
            {
                _log.LogInformation("The latest sighting could not be found.");
                return NotFound("The latest sighting could not be found.");
            }
            return Ok("The latest sighting was found.");
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> ReadOne(int id)
        {
            Sighting singleSighting = await _db.ReadOne(id);

            if (singleSighting == null)
            {
                _log.LogInformation("The sighting was not found.");
                return NotFound("The sighting was not found.");
            }
            return Ok("The sighting was found.");
        }

        [HttpPut]
        public async Task<ActionResult> Update(Sighting updateSighting)
        {
            bool returOK = await _db.Update(updateSighting);

            if (!returOK)
            {
                _log.LogInformation("The sighting could not be updated.");
                return NotFound("The sighting could not be updated.");
            }
            return Ok("The sighting is now changed.");
        }
    }

}
