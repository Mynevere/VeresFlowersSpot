using FlowrSpotPovio.Interfaces;
using FlowrSpotPovio.Models;
using FlowrSpotPovio.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FlowrSpotPovio.Controllers
{
    public class SightingController : BaseApiController
    {
        private readonly ISightingRepository sightingRepository;

        public SightingController(ISightingRepository sightingRepository)
        {
            this.sightingRepository = sightingRepository;
        }

        [HttpGet("getSightingByFlowerId/{flowerId}")]
        public async Task<IActionResult> GetSightingByFlowerId(Guid flowerId)
        {
            var result = await sightingRepository.GetSightingsByFlowerId(flowerId);
            return Ok(result);
        }

        [HttpPost("createSighting")]
        public async Task<IActionResult> CreateSighting([FromQuery] SightingViewModel sightingViewModel,IFormFile image) 
        {
            var result = await sightingRepository.CreateSighting(sightingViewModel, image);
            return Ok(result);
        }
    }
}
