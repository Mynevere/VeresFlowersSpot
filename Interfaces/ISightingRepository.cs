using FlowrSpotPovio.Models;
using FlowrSpotPovio.ViewModels;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FlowrSpotPovio.Interfaces
{
    public interface ISightingRepository
    {
        Task<List<Sighting>> GetSightingsByFlowerId(Guid flowerId);
        Task<Sighting> CreateSighting(SightingViewModel sightingViewModel, IFormFile image);
        Task<bool> DestroySighting(Guid sightingId);
    }
}
