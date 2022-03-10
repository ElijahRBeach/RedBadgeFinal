using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TravelLog.Models.State
{
    public class StateUpdate
    {
        [Required]
        public int StateId { get; set; }
        public string Name { get; set; }
    }
}