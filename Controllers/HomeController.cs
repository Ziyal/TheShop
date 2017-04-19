using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TheShop.Models;

namespace TheShop.Controllers
{
    public class HomeController : Controller
    {
        private TheShopContext _context;
    
        public HomeController(TheShopContext context)
        {
            _context = context;
        }

        [HttpGet]
        [Route("")]
        public IActionResult Index(){
            ViewBag.Products = _context.Products.OrderByDescending(prod => prod.CreatedAt);            
            ViewBag.Orders = _context.Orders.OrderByDescending(ord => ord.CreatedAt).Include(order => order.Customer).Include(order => order.Product);         
            ViewBag.Customers = _context.Customers.OrderByDescending(person => person.CreatedAt);

            return View();
        }
    }
}
