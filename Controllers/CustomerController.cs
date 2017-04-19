using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TheShop.Models;

namespace TheShop.Controllers
{
    public class CustomerController : Controller
    {
        private TheShopContext _context;
    
        public CustomerController(TheShopContext context)
        {
            _context = context;
        }

        [HttpGet]
        [Route("customers")]
        public IActionResult Customers(){
            ViewBag.Customers = _context.Customers;
            return View("Customers");
        }

        [HttpGet]
        [Route("delete-customer/{id}")]
        public IActionResult DeleteCustomer(int id){
            Customer RemoveCustomer = _context.Customers.Where(customer => customer.CustomerId == id).SingleOrDefault();
            System.Console.WriteLine(RemoveCustomer);
            _context.Remove(RemoveCustomer);
            _context.SaveChanges();
            return View("Customers");
        }

        [HttpPost]
        [Route("add-customer")]
        public IActionResult AddCustomers(Customer model){

            if (model == null) {
                TempData["Errors"] = "Name must not be empty";
                return RedirectToAction("Customers");
            }
            Customer NewCustomer = new Customer {
                Name = model.Name,
                CreatedAt = DateTime.Now,
                UpdatedAt = DateTime.Now
            };
            _context.Add(NewCustomer);
            _context.SaveChanges();

            return RedirectToAction("Customers");
        }        
    }
}
