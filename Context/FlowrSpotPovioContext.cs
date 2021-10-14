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
        public DbSet<Flower> Flowers { get; set; }


        public FlowrSpotPovioContext(DbContextOptions<FlowrSpotPovioContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //map entities to tables
            modelBuilder.Entity<User>().ToTable("Users");
            modelBuilder.Entity<Flower>().ToTable("Flowers");

            //configure primary keys
            modelBuilder.Entity<Flower>().HasKey(f => f.Id).HasName("PK_Flowers");

            //configure columns
            modelBuilder.Entity<Flower>(entity =>
            {
                entity.HasKey(f => f.Id).HasName("PK_Flowers_Id");
                entity.Property(e => e.Name).IsRequired().HasMaxLength(50);
                entity.Property(e => e.Image).HasMaxLength(1000);
                entity.Property(e => e.Description).IsRequired().HasMaxLength(2000);
            });
        }
    }
}
