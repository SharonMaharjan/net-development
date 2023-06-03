using Microsoft.AspNetCore.Mvc.Rendering;

namespace MotoGPPractice.Models.ViewModels
{
    public class SelectRaceViewModel
    {
        public SelectList Races { get; set; }
        public int raceID { get; set; }
        public Race SelectedRace { get; internal set; }
    }
}
