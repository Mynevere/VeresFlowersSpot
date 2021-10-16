using FlowrSpotPovio.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace FlowrSpotPovio.Controllers
{
    public class LikeController : BaseApiController
    {
        private readonly ILikeRepository likeRepository;

        public LikeController(ILikeRepository likeRepository)
        {
            this.likeRepository = likeRepository;
        }

        [Authorize(AuthenticationSchemes = "Bearer")]
        [HttpPost("likeSighting/{sightingId}")]
        public async Task<IActionResult> LikeSighting(Guid sightingId)
        {
            var result = await likeRepository.LikeSighting(sightingId);
            return Ok(result);
        }
    }
}
