using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace TheShop.Models
{
    public class Product : BaseEntity
    {
        [Key]
        public int ProductsId { get; set; }
        public string Name { get; set; }
        public string Image { get; set; }
        public string Description { get; set; }
        public int Quantity { get; set; }
        public DateTime CreatedAt { get; set;}
        public DateTime UpdatedAt { get; set;}
        public List<Order> Orders { get; set; }
        public Product() {
            Orders = new List<Order>();
        }
    }
}