using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FlowrSpotPovio.Models
{
    public class Sighting
    {
        public Guid Id { get; set; }
        public decimal Longitude { get; set; }
        public decimal Latitude { get; set; }
        public Guid FlowerId { get; set; }
        public Flower Flower { get; set; }
        public string UserId { get; set; }
        public User User { get; set; }
        public string Image { get; set; }
        public string Question { get; set; } 
    }
}
