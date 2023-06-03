using Microsoft.AspNetCore.Mvc.Rendering;

namespace MusicStorePractice.Models.ViewModels
{
    public class ListAlbumsViewModel
    {
        public List<Album> Albums;
        public SelectList Artists { get; set; }
        public int artistID { get; set; }
        public SelectList Genres { get; set; }
        public int genreID { get; set; }


    }
}
