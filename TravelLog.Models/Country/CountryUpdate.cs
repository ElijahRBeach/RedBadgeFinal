using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TravelLog.Models.Country
{
    public class CountryUpdate
    {
        [Required]
        public int CountryId { get; set; }
        public string Name { get; set; }
    }
}