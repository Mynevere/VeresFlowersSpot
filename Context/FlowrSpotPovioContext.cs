using FlowrSpotPovio.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FlowrSpotPovio.Context
{
    public class FlowrSpotPovioContext : DbContext
    {
        public DbSet<User> Users { get; set; }

        public FlowrSpotPovioContext(DbContextOptions<FlowrSpotPovioContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //map entities to tables
            modelBuilder.Entity<User>().ToTable("Users");
        }
    }
}
