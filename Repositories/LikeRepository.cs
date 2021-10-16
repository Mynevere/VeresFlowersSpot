using FlowrSpotPovio.Context;
using FlowrSpotPovio.Helpers.Errors;
using FlowrSpotPovio.Interfaces;
using FlowrSpotPovio.Models;
using FlowrSpotPovio.ViewModels;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace FlowrSpotPovio.Repositories
{
    public class LikeRepository : ILikeRepository
    {
        private readonly FlowrSpotPovioContext context;
        private readonly IAuthRepository authRepository;

        public LikeRepository(FlowrSpotPovioContext context, IAuthRepository authRepository)
        {
            this.context = context;
            this.authRepository = authRepository;
        }

        public async Task<Like> LikeSighting(Guid sightingId)
        {
            var exits = await context.Likes.Select(x => x.SightingId == sightingId).FirstOrDefaultAsync();
            if(exits)
                throw new RestException(HttpStatusCode.BadRequest, "Liked");

            var like = new Like
            {
                UserId = authRepository.GetCurrentUser().Result.Id,
                SightingId = sightingId
            };

            await context.Likes.AddAsync(like);
            await context.SaveChangesAsync();
            return like;
        }
    }
}
