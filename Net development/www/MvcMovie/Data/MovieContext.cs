using MvcMovie.Models;
using Microsoft.EntityFrameworkCore;

namespace MvcMovie.Data
{
	public class MovieContext : DbContext
	{
		public MovieContext(DbContextOptions<MovieContext> options) : base(options)
		{
		}

		public DbSet<Movie> Movies;
		public DbSet<Rating> Ratings;

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<Movie>().ToTable("Movie");
			modelBuilder.Entity<Rating>().ToTable("Rating");
		}
	}
}