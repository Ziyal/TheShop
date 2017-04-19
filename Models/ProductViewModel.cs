using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace TheShop.Models
{
    public class ProductViewModel : BaseEntity
    {

        [Required]
        public string Name { get; set; }

        [Required]
        public string Image { get; set; }

        [Required]
        [MinLength(15)]
        public string Description { get; set; }

        [Required]
        [RangeAttribute(1,50, ErrorMessage = "Please enter a valid quantity")]
        public int Quantity { get; set; }        
    }
}