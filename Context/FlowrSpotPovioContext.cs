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
        public DbSet<Sighting> Sightings { get; set; }
        public DbSet<Like> Likes { get; set; }


        public FlowrSpotPovioContext(DbContextOptions<FlowrSpotPovioContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //map entities to tables
            modelBuilder.Entity<User>().ToTable("Users");
            modelBuilder.Entity<Flower>().ToTable("Flowers");
            modelBuilder.Entity<Sighting>().ToTable("Sighting");

            //configure columns
            modelBuilder.Entity<Flower>(entity =>
            {
                entity.HasKey(f => f.Id).HasName("PK_Flowers_Id");
                entity.Property(e => e.Name).IsRequired().HasMaxLength(50);
                entity.Property(e => e.Image).HasMaxLength(1000);
                entity.Property(e => e.Description).IsRequired().HasMaxLength(2000);
            });

            modelBuilder.Entity<Sighting>(entity =>
            {
                entity.HasKey(s => s.Id).HasName("PK_Sighting_Id");
                entity.Property(s => s.Longitude).HasColumnType("Decimal(9,6)");
                entity.Property(s => s.Latitude).HasColumnType("Decimal(8,6)");
                entity.Property(s => s.Image).HasMaxLength(1000);
            });

            modelBuilder.Entity<Sighting>()
           .HasOne(p => p.User)
           .WithMany()
           .HasForeignKey(p => p.UserId)
           .HasConstraintName("FK_Sighting_UserId");

            modelBuilder.Entity<Sighting>()
           .HasOne(p => p.Flower)
           .WithMany()
           .HasForeignKey(p => p.FlowerId)
           .HasConstraintName("FK_Sighting_FlowerId");

            modelBuilder.Entity<Like>(entity =>
            {
                entity.HasKey(s => s.Id).HasName("PK_Like_Id");
            });

            modelBuilder.Entity<Like>()
           .HasOne(p => p.User)
           .WithMany()
           .HasForeignKey(p => p.UserId)
           .HasConstraintName("FK_Like_UserId");

            modelBuilder.Entity<Like>()
           .HasOne(p => p.Sighting)
           .WithMany()
           .HasForeignKey(p => p.SightingId)
           .HasConstraintName("FK_Like_SightingId");
        }
    }
}
