using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TravelLog.Data.Entities
{
    public class CountryEntity
    {
        [Key]
        public int CountryId { get; set; }
        [Required]
        public string Name { get; set; }
        public List<StateEntity> States { get; set; }
        public List<CityEntity> Cities { get; set; }
    }
}