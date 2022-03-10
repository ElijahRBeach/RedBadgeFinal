using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TravelLog.Models.State
{
    public class StateCreate
    {
        [Required]
        public string Name { get; set; }
        
        [Range(1, int.MaxValue)]
        public int? CountryId { get; set; }
    }
}