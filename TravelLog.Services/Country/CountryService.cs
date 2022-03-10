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

namespace TravelLog.Services.Country
{
    public class CountryService : ICountryService
    {
        private readonly ApplicationDbContext _dbContext;

        public CountryService(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        //CreateCountry method

        public async Task<bool> CreateCountryAsync(CountryCreate request)
        {
            var countryEntity = new CountryEntity
            {
                Name = request.Name
            };

            _dbContext.Countries.Add(countryEntity);

            var numberOfChanges = await _dbContext.SaveChangesAsync();
            return numberOfChanges == 1;
        }

        //GetCountryById method
        public async Task<CountryDetail> GetCountryByIdAsync(int countryId)
        {
            var countryEntity = await _dbContext.Countries
                .Include(a => a.States)
                .Include(a => a.Cities)
                .FirstOrDefaultAsync(e => e.CountryId == countryId);

            return countryEntity is null ? null : new CountryDetail
            {
                CountryId = countryEntity.CountryId,
                Name = countryEntity.Name,
                States = countryEntity.States.Select(entity => new StateListItem
                {
                    StateId = entity.StateId,
                    Name = entity.Name
                }).ToList(),
                Cities = countryEntity.Cities.Select(entity => new CityListItem
                {
                    CityId = entity.CityId,
                    Name = entity.Name
                }).ToList()
            };
        }

        //GetAllCountriesMethod
        public async Task<IEnumerable<CountryListItem>> GetAllCountriesAsync()
        {
            var countries = await _dbContext.Countries
                .Select(entity => new CountryListItem
                {
                    CountryId = entity.CountryId,
                    Name = entity.Name
                }).ToListAsync();
            return countries;
        }

        // UpdateCountry method
        public async Task<bool> UpdateCountryAsync(CountryUpdate request)
        {
            var countryEntity = await _dbContext.Countries.FindAsync(request.CountryId);

            if (countryEntity == null)
                return false;

            if(!string.IsNullOrWhiteSpace(request.Name))
                countryEntity.Name = request.Name;
            
            var numberOfChanges = await _dbContext.SaveChangesAsync();

            return numberOfChanges == 1;
        }

        //DeleteCountry method
        public async Task<bool> DeleteCountryAsync(int countryId)
        {
            var countryEntity = await _dbContext.Countries.FindAsync(countryId);

            if (countryEntity == null)
                return false;

            _dbContext.Countries.Remove(countryEntity);
            return await _dbContext.SaveChangesAsync() == 1;
        }
    }
}