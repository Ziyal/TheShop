using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TheShop.Models;

namespace TheShop.Controllers
{
    public class ProductController : Controller
    {
        private TheShopContext _context;
    
        public ProductController(TheShopContext context){
            _context = context;
        }

        [HttpGet]
        [Route("products")]
        public IActionResult Products() {
            ViewBag.Products = _context.Products;
            return View("Products");
        }     

        [HttpPost]
        [Route("add-product")]
        public IActionResult AddProduct(ProductViewModel model){
            List<string> allErrors = new List <string>();
            
            if (ModelState.IsValid) {
                Product NewProduct = new Product {
                    Name = model.Name,
                    Image = model.Image,
                    Description = model.Description,
                    Quantity = model.Quantity,
                    CreatedAt = DateTime.Now,
                    UpdatedAt = DateTime.Now
                };
                _context.Add(NewProduct);
                _context.SaveChanges();
                return RedirectToAction("Products");
            }

            // If there are validation errors:
            foreach (var i in ModelState.Values) {
                if (i.Errors.Count > 0) {
                    allErrors.Add(i.Errors[0].ErrorMessage.ToString());
                }
            }
            TempData["Errors"] = allErrors;
            return RedirectToAction("Products");
        }           


    }
}
