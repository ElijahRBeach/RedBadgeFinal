using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TravelLog.Models.Country;
using TravelLog.Models.State;

namespace TravelLog.Models.City
{
    public class CityDetail
    {
        public int CityId { get; set; }
        public string Name { get; set; }
        public CountryListItem Country { get; set; }
        public StateListItem State { get; set; }
    }
}