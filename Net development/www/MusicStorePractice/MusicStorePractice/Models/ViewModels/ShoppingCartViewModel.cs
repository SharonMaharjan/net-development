using Microsoft.AspNetCore.Mvc.Rendering;

namespace MusicStorePractice.Models.ViewModels
{
    public class ShoppingCartViewModel
    {
        public List<Album> Albums;
        public SelectList CartItems { get; set; }
        public int cartItemID { get; set; }
       
    }
}
