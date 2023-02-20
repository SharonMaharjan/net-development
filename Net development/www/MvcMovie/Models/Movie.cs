using System;

namespace MvcMovie.Models
{
	public class Movie
	{
		public int MovieID { get; set; }
		public string Title { get; set; }
		public DateTime ReleaseDate { get; set; }
		public string Genre { get; set; }
		public int? Price { get; set; }
		public int RatingID { get; set; }

		public Rating? Rating { get; set; }
	}
}
