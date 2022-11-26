using UFO_Webapplikasjon.Model;
using Microsoft.EntityFrameworkCore;
using System.Data;
using Microsoft.AspNetCore.Mvc;

namespace UFO_Webapplikasjon.DAL
{
    public class SightingRepository : InSightingRepository
    {
        private readonly SightingContext _db;

        public SightingRepository(SightingContext db)
        {
            _db = db;
        }

        public async Task<bool> Create(Sighting innSighting)
        {
            try
            {
                var newSightingRow = new Sightings();

                newSightingRow.City = innSighting.City;
                newSightingRow.Country = innSighting.Country;
                newSightingRow.Duration = innSighting.Duration;
                newSightingRow.Dateposted = innSighting.Dateposted;
                newSightingRow.Datetime = innSighting.Datetime;
                newSightingRow.Comments = innSighting.Comments;

                _db.Sightings.Add(newSightingRow);
                await _db.SaveChangesAsync();
                return true;
            }
            catch
            {
                return false;
            }
        }


        public async Task<List<Sighting>?> ReadAll()
        {
            try
            {
                List<Sighting> everySightings = await _db.Sightings.Select(k => new Sighting
                {
                    Id = k.Id,
                    City = k.City,
                    Country = k.Country,
                    Duration = k.Duration,
                    Datetime = k.Datetime,
                    Dateposted = k.Dateposted,
                    Comments = k.Comments,
                }).ToListAsync();

                return everySightings;
            }
            catch
            {
                return null;
            }
        }

        // Sorts order of ReadAll() based on Country
        public async Task<List<Sighting>?> ReadCountryAsc()
        {
            try
            {
                List<Sighting> everySightings = await _db.Sightings.Select(k => new Sighting
                {
                    Id = k.Id,
                    City = k.City,
                    Country = k.Country,
                    Duration = k.Duration,
                    Datetime = k.Datetime,
                    Dateposted = k.Dateposted,
                    Comments = k.Comments,
                }).OrderBy(x => x.Country).ToListAsync();

                return everySightings;
            }
            catch
            {
                return null;
            }
        }

        // Reversed order of ReadAll() based on Country
        public async Task<List<Sighting>?> ReadCountryDesc()
        {
            try
            {
                List<Sighting> everySightings = await _db.Sightings.Select(k => new Sighting
                {
                    Id = k.Id,
                    City = k.City,
                    Country = k.Country,
                    Duration = k.Duration,
                    Datetime = k.Datetime,
                    Dateposted = k.Dateposted,
                    Comments = k.Comments,
                }).OrderByDescending(x => x.Country).ToListAsync();

                return everySightings;
            }
            catch
            {
                return null;
            }
        }

        // Sorts order of ReadAll() based on City
        public async Task<List<Sighting>?> ReadCityAsc()
        {
            try
            {
                List<Sighting> everySightings = await _db.Sightings.Select(k => new Sighting
                {
                    Id = k.Id,
                    City = k.City,
                    Country = k.Country,
                    Duration = k.Duration,
                    Datetime = k.Datetime,
                    Dateposted = k.Dateposted,
                    Comments = k.Comments,
                }).OrderBy(x => x.City).ToListAsync();

                return everySightings;
            }
            catch
            {
                return null;
            }
        }

        // Reversed order of ReadAll() based on City
        public async Task<List<Sighting>?> ReadCityDesc()
        {
            try
            {
                List<Sighting> everySightings = await _db.Sightings.Select(k => new Sighting
                {
                    Id = k.Id,
                    City = k.City,
                    Country = k.Country,
                    Duration = k.Duration,
                    Datetime = k.Datetime,
                    Dateposted = k.Dateposted,
                    Comments = k.Comments,
                }).OrderByDescending(x => x.City).ToListAsync();

                return everySightings;
            }
            catch
            {
                return null;
            }
        }

        // Reversed order of ReadAll() based on Id
        public async Task<List<Sighting>?> ReadIdDesc()
        {
            try
            {
                List<Sighting> everySightings = await _db.Sightings.Select(k => new Sighting
                {
                    Id = k.Id,
                    City = k.City,
                    Country = k.Country,
                    Duration = k.Duration,
                    Datetime = k.Datetime,
                    Dateposted = k.Dateposted,
                    Comments = k.Comments,
                }).OrderByDescending(x => x.Id).ToListAsync();

                return everySightings;
            }
            catch
            {
                return null;
            }
        }

        // Reversed order of ReadAll() based on Id and get a single Object
        public async Task<Sighting> ReadLatest()
        {
            try
            {
                List<Sighting> everySightings = await _db.Sightings.Select(k => new Sighting
                {
                    Id = k.Id,
                    City = k.City,
                    Country = k.Country,
                    Duration = k.Duration,
                    Datetime = k.Datetime,
                    Dateposted = k.Dateposted,
                    Comments = k.Comments,
                }).OrderByDescending(x => x.Id).ToListAsync();

                var latestRecord = everySightings.FirstOrDefault();

                return latestRecord;
            }
            catch
            {
                return null;
            }
        }

        public async Task<Sighting> ReadOne(int Id)
        {
            Sightings singleSighting = await _db.Sightings.FindAsync(Id);
            var hentetKunde = new Sighting()
            {
                Id = singleSighting.Id,
                City = singleSighting.City,
                Country = singleSighting.Country,
                Duration = singleSighting.Duration,
                Dateposted = singleSighting.Dateposted,
                Datetime = singleSighting.Datetime,
                Comments = singleSighting.Comments,
            };
            return hentetKunde;
        }

        public async Task<bool> Delete(int id)
        {
            try
            {
                Sightings singleDBSighting = await _db.Sightings.FindAsync(id);
                _db.Sightings.Remove(singleDBSighting);
                await _db.SaveChangesAsync();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public async Task<bool> Update(Sighting updateSighting)
        {
            try
            {
                var updateObjekt = await _db.Sightings.FindAsync(updateSighting.Id);
                updateObjekt.City = updateSighting.City;
                updateObjekt.Country = updateSighting.Country;
                updateObjekt.Duration = updateSighting.Duration;
                updateObjekt.Dateposted = updateSighting.Dateposted;
                updateObjekt.Datetime = updateSighting.Datetime;
                updateObjekt.Comments = updateSighting.Comments;
                await _db.SaveChangesAsync();
            }
            catch
            {
                return false;
            }
            return true;
        }

    }
}
