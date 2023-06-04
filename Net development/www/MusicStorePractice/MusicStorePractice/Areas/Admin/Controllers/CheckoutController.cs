using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MusicStorePractice.Data;
using MusicStorePractice.Models;

namespace MusicStorePractice.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize]
    public class CheckoutController : Controller
    {
        private readonly StoreContext _context;

        public CheckoutController(StoreContext context)
        {
            _context = context;
        }

       

        // GET: Admin/Checkout/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Admin/Checkout/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("OrderID,Address,Name,OrderDate,Username")] Order order)
        {
            if (ModelState.IsValid)
            {
                order.Username = HttpContext.User.Identity.Name;
                order.OrderDate = DateTime.Now;

                _context.Add(order);
                _context.SaveChanges();

                var cart = new ShoppingCart(HttpContext, _context);
                cart.CreateOrderItems(order);

                await _context.SaveChangesAsync();
                return RedirectToAction("Complete", new { id = order.OrderID });
            }
            return View(order);
        }




        private bool OrderExists(int id)
        {
          return _context.Orders.Any(e => e.OrderID == id);
        }
    }
}
