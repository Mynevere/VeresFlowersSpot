using FlowrSpotPovio.Context;
using FlowrSpotPovio.Helpers.Errors;
using FlowrSpotPovio.Interfaces;
using FlowrSpotPovio.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace FlowrSpotPovio.Repositories
{
    public class FlowerRepository : IFlowerRepository
    {
        private readonly FlowrSpotPovioContext context;

        public FlowerRepository(FlowrSpotPovioContext context)
        {
            this.context = context;
        }

        public async Task<List<Flower>> GetAllFlowers()
        {
            var flowers = await context.Flowers.ToListAsync();
            if(flowers == null)
                throw new RestException(HttpStatusCode.BadRequest, "There are no flowers!");
            return flowers;
        }
    }
}
