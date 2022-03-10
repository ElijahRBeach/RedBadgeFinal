using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TravelLog.Models.State;

namespace TravelLog.Models.Country
{
    public class CountryStatesListItem
    {
        public List<StateListItem> States { get; set; }
    }
}