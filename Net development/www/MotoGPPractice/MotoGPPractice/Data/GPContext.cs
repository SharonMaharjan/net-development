﻿using Microsoft.EntityFrameworkCore;
using MotoGPPractice.Models;

namespace MotoGPPractice.Data
{
    public class GPContext: DbContext
    {
        public GPContext(DbContextOptions<GPContext> options) : base(options) { }

        public DbSet<Country> Countries { get; set; }
        public DbSet<Team> Teams { get; set; }
        public DbSet<Race> Races { get; set; }
        
        public DbSet<Rider> Riders { get; set; }
        
        public DbSet<Ticket> Tickets { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Country>().ToTable("Country");
            modelBuilder.Entity<Team>().ToTable("Team");
            modelBuilder.Entity<Race>().ToTable("Race");
            modelBuilder.Entity<Rider>().ToTable("Rider");
            modelBuilder.Entity<Ticket>().ToTable("Ticket");
        }
    }
}
