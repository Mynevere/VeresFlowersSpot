using FlowrSpotPovio.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FlowrSpotPovio.Interfaces
{
    public interface IFlowerRepository
    {
        Task<List<Flower>> GetAllFlowers();
    }
}
