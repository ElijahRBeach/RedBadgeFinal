using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TravelLog.Data.Entities
{
    public class StateEntity
    {
        [Key]
        public int StateId { get; set; }
        [Required]
        public string Name { get; set; }
        public int? CountryId {get; set;}
        public CountryEntity Country { get; set; }
        public List<CityEntity> Cities { get; set; }
    }
}