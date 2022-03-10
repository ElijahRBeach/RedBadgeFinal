using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TravelLog.Data.Entities
{
    public class CityEntity
    {
        [Key]
        public int CityId { get; set; }
        [Required]
        public string Name { get; set; }
        public int? CountryId { get; set; }
        public CountryEntity Country { get; set; }
        public int? StateId { get; set; }
        public StateEntity State { get; set; }
    }
}