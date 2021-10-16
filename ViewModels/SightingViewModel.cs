using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FlowrSpotPovio.ViewModels
{
    public class SightingViewModel
    {
        public decimal Longitude { get; set; }
        public decimal Latitude { get; set; }
        public Guid FlowerId { get; set; }
        public string Question { get; set; }
    }
}
