using Microsoft.AspNetCore.Mvc.Rendering;

namespace MotoGPPractice.Models.ViewModels
{
    public class ListTeamsRidersViewModel
    {
        public List<Rider> Riders { get; set; }
        public SelectList Teams { get; set; }
        public int TeamID { get; set; }
    }
}