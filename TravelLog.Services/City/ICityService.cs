using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TravelLog.Models.City;

namespace TravelLog.Services.City
{
    public interface ICityService
    {
        Task<bool> CreateCityAsync(CityCreate request);

        Task<CityDetail> GetCityByIdAsync(int cityId);

        Task<IEnumerable<CityListItem>> GetAllCitiesAsync();

        Task<bool> UpdateCityAsync(CityUpdate request);

        Task<bool> DeleteCityAsync(int cityId);
    }
}