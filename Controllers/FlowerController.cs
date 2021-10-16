using FlowrSpotPovio.Interfaces;
using FlowrSpotPovio.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FlowrSpotPovio.Controllers
{
    public class FlowerController : BaseApiController
    {

        private readonly IFlowerRepository flowerRepository;

        public FlowerController(IFlowerRepository flowerRepository)
        {
            this.flowerRepository = flowerRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllFlowers() 
        {
            var result = await flowerRepository.GetAllFlowers();
            return Ok(result);
        }
    }
}
