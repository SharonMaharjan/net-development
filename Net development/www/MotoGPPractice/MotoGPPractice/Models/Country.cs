namespace MotoGPPractice.Models
{
    public class Country
    {
        public int CountryID { get; set; }
        public string Name { get; set; }

        public ICollection<Ticket>? Tickets { get; set; }
        public ICollection<Rider>? Riders { get; set; }
    }
}
