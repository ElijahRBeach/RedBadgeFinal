using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TravelLog.Data;
using TravelLog.Data.Entities;
using TravelLog.Models.City;
using TravelLog.Models.Country;
using TravelLog.Models.State;

namespace TravelLog.Services.City
{
    public class CityService : ICityService
    {
        private readonly ApplicationDbContext _dbContext;

        public CityService(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        //CreateCity method
        public async Task<bool> CreateCityAsync(CityCreate request)
        {
            var cityEntity = new CityEntity
            {
                CityId = request.CityId,
                CountryId = request.CountryId,
                Name = request.Name
            };

            _dbContext.Cities.Add(cityEntity);

            var numberOfChanges = await _dbContext.SaveChangesAsync();
            return numberOfChanges == 1;
        }

        //GetAllCities method
        public async Task<IEnumerable<CityListItem>> GetAllCitiesAsync()
        {
            var cities = await _dbContext.Cities
            .Select(entity => new CityListItem
            {
                CityId = entity.CityId,
                Name = entity.Name
            }).ToListAsync();

            return cities;
        }

        //GetCityById method
        public async Task<CityDetail> GetCityByIdAsync(int cityId)
        {
            var cityEntity = await _dbContext.Cities
            .Include(y => y.Country)
            .Include(y => y.State)
            .FirstOrDefaultAsync(e => e.CityId == cityId);

            if (cityEntity is null)
                return null;

            return new CityDetail
            {
                CityId = cityEntity.CityId,
                Name = cityEntity.Name,
                Country = new CountryListItem()
                {
                    CountryId = cityEntity.Country?.CountryId ?? 0,
                    Name = cityEntity.Country?.Name ?? "City not associated with country"
                },
                State = new StateListItem()
                {
                    StateId = cityEntity.State?.StateId ?? 0,
                    Name = cityEntity.State?.Name ?? "City not associated with state"
                }
            };
        }

        //UpdateCityAsync
        public async Task<bool> UpdateCityAsync(CityUpdate request)
        {
            var cityEntity = await _dbContext.Cities.FindAsync(request.CityId);

            if(cityEntity is null)
                return false;

            if(!string.IsNullOrWhiteSpace(request.Name))
                cityEntity.Name = request.Name;

            var numberOfChanges = await _dbContext.SaveChangesAsync();

            return numberOfChanges == 1;
        }

        //DeleteCity
        public async Task<bool> DeleteCityAsync(int cityId)
        {
            var cityEntity = await _dbContext.Cities.FindAsync(cityId);

            if (cityEntity is null)
                return false;

            _dbContext.Cities.Remove(cityEntity);
            var numberOfChanges = await _dbContext.SaveChangesAsync();
            return numberOfChanges == 1;
        }
    }
}