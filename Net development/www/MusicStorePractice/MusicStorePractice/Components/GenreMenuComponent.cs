using Microsoft.AspNetCore.Mvc;
using MusicStorePractice.Data;
using MusicStorePractice.Models;

namespace MusicStorePractice.Components
{
    [ViewComponent(Name="GenreMenu")]
    public class GenreMenuComponent:ViewComponent
    {
        private readonly StoreContext _context;
        public GenreMenuComponent(StoreContext context) {
            _context = context;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var genres = _context.Genres.Take(8).ToList();
            return View(genres);

        }
    }
}
