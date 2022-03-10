using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TravelLog.Models.Country;

namespace TravelLog.Services.Country
{
    public interface ICountryService
    {
        Task<bool> CreateCountryAsync(CountryCreate request);

        Task<CountryDetail> GetCountryByIdAsync(int countryId);

        Task<IEnumerable<CountryListItem>> GetAllCountriesAsync();

        Task<bool> UpdateCountryAsync(CountryUpdate request);

        Task<bool> DeleteCountryAsync(int countryId);
    }
}