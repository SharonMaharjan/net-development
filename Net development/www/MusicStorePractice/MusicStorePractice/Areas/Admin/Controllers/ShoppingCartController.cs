using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using MusicStorePractice.Data;
using MusicStorePractice.Models;
using MusicStorePractice.Models.ViewModels;

namespace MusicStorePractice.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Administrator")]
    public class ShoppingCartController : Controller
    {
        private readonly StoreContext _context;
        private readonly ShoppingCart _shoppingCart;

        public ShoppingCartController(StoreContext context, ShoppingCart shoppingCart)
        {
            _context = context;
            _shoppingCart = shoppingCart;
        }
        public IActionResult Index()
        {
            var cartItems = _shoppingCart.GetCartItems();
            var customViewModel = new ShoppingCartViewModel()
            {
                Albums = cartItems.Select(item => item.Album).ToList(),
                CartItems = new SelectList(cartItems, "CartItemID", "CartItemID"),
                cartItemID = 0 // Set the default selected item in the SelectList
            };

            return View(cartItems);
        }

        public IActionResult AddToCart(int albumId, bool remove = false)
        {
            var album = _context.Albums.SingleOrDefault(a => a.AlbumID == albumId);

            if (album != null)
            {
                if (remove)
                {
                    //_shoppingCart.RemoveFromCart(albumId);
                }
                else
                {
                    _shoppingCart.AddToCart(album);
                }
            }

            return RedirectToAction("Index");
        }
    }
}
