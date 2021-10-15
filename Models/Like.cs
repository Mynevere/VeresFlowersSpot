using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FlowrSpotPovio.Models
{
    public class Like
    {
        public Guid Id { get; set; }
        public string UserId { get; set; }
        public User User { get; set; }
        public Guid SightingId { get; set; }
        public Sighting Sighting { get; set; } 
    }
}
