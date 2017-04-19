using System;
using System.Collections.Generic;

namespace TheShop.Models
{
    public class Customer : BaseEntity
    {

        public int CustomerId { get; set; }
        public string Name { get; set; }
        public DateTime CreatedAt { get; set;}
        public DateTime UpdatedAt { get; set;}
        public List<Order> Orders { get; set; }

        public Customer() {
            Orders = new List<Order>();
        }


        
    }
}