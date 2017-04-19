using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TheShop.Models;

namespace TheShop.Controllers
{
    public class OrderController : Controller
    {
        private TheShopContext _context;
    
        public OrderController(TheShopContext context)
        {
            _context = context;
        }
        
        [HttpGet]
        [Route("orders")]
        public IActionResult Orders(){
            ViewBag.Customers = _context.Customers;
            ViewBag.Items = _context.Products;
            ViewBag.Orders = _context.Orders.OrderBy(order => order.CreatedAt).Include(order => order.Customer).Include(order => order.Product);
            return View("Orders");
        }  

        [HttpPost]
        [Route("add-order")]
        public IActionResult AddOrder(int CustomerId, int ProductsId, int Quantity)
        {
            Product ThisProduct = _context.Products.Where(p => p.ProductsId == ProductsId).SingleOrDefault();
            if (Quantity > ThisProduct.Quantity) {
                ViewBag.Error = "Sorry, there are only {ThisProduct.Quantity} left";
                return View("Orders");
            }

            ThisProduct.Quantity -= Quantity;
            Order NewOrder = new Order {
                CustomerId = CustomerId,
                ProductsId = ProductsId,
                Quantity = Quantity,
                CreatedAt = DateTime.Now,
                UpdatedAt = DateTime.Now
            };
            _context.Add(NewOrder);
            _context.SaveChanges();
            
            return RedirectToAction("Orders");
        } 
    


    }
}
