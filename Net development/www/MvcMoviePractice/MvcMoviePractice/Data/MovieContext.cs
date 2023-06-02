using Microsoft.EntityFrameworkCore;
using MvcMoviePractice.Models;

namespace MvcMoviePractice.Data
{
    public class MovieContext: DbContext
    {
        public MovieContext(DbContextOptions<MovieContext> options) : base(options)
        {

        }

        public DbSet<Movie> Movies { get; set; }
        public DbSet<Rating> Ratings { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Movie>().ToTable("Movie");
            modelBuilder.Entity<Rating>().ToTable("Rating");
        }
        
    }
}
