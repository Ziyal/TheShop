using Microsoft.EntityFrameworkCore;
 
namespace TheShop.Models
{
    public class TheShopContext : DbContext
    {
        // base() calls the parent class' constructor passing the "options" parameter along
        public TheShopContext(DbContextOptions<TheShopContext> options) : base(options) { }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Product> Products { get; set; }    
    }
}