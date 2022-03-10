using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TravelLog.Models.City;
using TravelLog.Models.Country;

namespace TravelLog.Models.State
{
    public class StateDetail
    {
        public int StateId { get; set; }
        public string Name { get; set; }
        public CountryListItem Country { get; set; }
        public List<CityListItem> Cities { get; set; }
    }
}