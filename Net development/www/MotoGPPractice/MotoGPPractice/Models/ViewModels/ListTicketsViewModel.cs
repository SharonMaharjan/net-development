using Microsoft.AspNetCore.Mvc.Rendering;

namespace MotoGPPractice.Models.ViewModels
{
    public class ListTicketsViewModel
    {
        public List<Ticket> Tickets;
        public SelectList Races { get; set; }
        public int raceID { get; set; }
        public Dictionary<int, string> CountryNames { get; set; } // New property for country names
        public Dictionary<int, string> RaceIDs { get; set; }
    }
}
