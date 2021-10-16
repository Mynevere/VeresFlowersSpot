using FlowrSpotPovio.Models;
using FlowrSpotPovio.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FlowrSpotPovio.Interfaces
{
    public interface ILikeRepository
    {
        Task<Like> LikeSighting(Guid sightingId);
        Task<bool> DestroyLike(Guid likeId); 
    }
}
