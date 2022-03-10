using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TravelLog.Models.City;
using TravelLog.Models.State;

namespace TravelLog.Models.Country
{
    public class CountryDetail
    {
        public int CountryId { get; set; }
        public string Name { get; set; }
        public List<StateListItem> States { get; set; }
        public List<CityListItem> Cities { get; set; }
    }
}