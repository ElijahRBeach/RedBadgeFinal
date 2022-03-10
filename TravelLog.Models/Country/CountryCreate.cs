using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TravelLog.Models.Country
{
    public class CountryCreate
    {
        [Required]
        public string Name { get; set; }
    }
}