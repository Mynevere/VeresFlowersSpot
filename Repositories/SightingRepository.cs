using FlowrSpotPovio.Context;
using FlowrSpotPovio.Helpers.Errors;
using FlowrSpotPovio.Interfaces;
using FlowrSpotPovio.Models;
using FlowrSpotPovio.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace FlowrSpotPovio.Repositories
{
    public class SightingRepository : ISightingRepository
    {
        private readonly FlowrSpotPovioContext context;
        private readonly IAuthRepository authRepository;

        public SightingRepository(FlowrSpotPovioContext context, IAuthRepository authRepository)
        {
            this.context = context;
            this.authRepository = authRepository;
        }

        public async Task<Sighting> CreateSighting(SightingViewModel sightingViewModel, IFormFile image)
        {

            var sighting = new Sighting
            {
                Latitude = sightingViewModel.Latitude,
                Longitude = sightingViewModel.Longitude,
                UserId = sightingViewModel.UserId,
                FlowerId = sightingViewModel.FlowerId
            };

            if (image != null)
            {
                string[] path = UploadImage(image); 
                sighting.Image = path[0];
            }

            await context.AddAsync(sighting);
            await context.SaveChangesAsync();
            return sighting;
        }

        public async Task<List<Sighting>> GetSightingsByFlowerId(Guid flowerId)
        {
            var sightings = await context.Sightings.Where(x => x.FlowerId == flowerId).ToListAsync();
            return sightings;
        }

        public async Task<bool> DestroySighting(Guid sightingId)
        {
            var currentUser = await authRepository.GetCurrentUser();
            var sighting = await context.Sightings.FindAsync(sightingId);

            if(sighting.UserId == currentUser.Id)
            {
                context.Sightings.Remove(sighting);
                await context.SaveChangesAsync();
                return true;
            }
            else
            {
                throw new RestException(HttpStatusCode.BadRequest, "You can't destory it!");
            }
        }


        public string[] UploadImage(IFormFile file)
        {
            string[] data = new string[2];

            if (file == null || file.Length == 0)
                return null;
            string fileName = Path.GetFileName(file.FileName);

            var firstPath = Directory.CreateDirectory(Directory.GetCurrentDirectory() + "\\SightingImages\\").FullName;

            string path = Path.Combine(firstPath, fileName);

            using (var stream = new FileStream(path, FileMode.Create))
            {
                file.CopyTo(stream);
            }

            data[0] = path;
            data[1] = fileName;

            return data;
        }
    }
}
