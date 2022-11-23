using HouseRentingSystem.Core.Models.Agent;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HouseRentingSystem.Core.Models.House
{
    public class HouseDetailsModel : HouseServiceModel
    {
        [Required]
        public string Description { get; set; } = null!;
        [Required]
        public string Category { get; set; } = null!;

        public AgentServiceModel Agent { get; set; } = null!;
    }
}
