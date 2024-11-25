using Microsoft.EntityFrameworkCore;
using System.CodeDom;
using Task2product.Models;

namespace Task2product.Context
{
    public class ProductContext2:DbContext
    {
        public ProductContext2(DbContextOptions options):base(options)
        {
            
        }
        public DbSet<Product2> product2s { get; set; }
        public DbSet<Customer> customers { get; set; }
        public DbSet<CustomerRoles> customerRoles { get; set; }
        public DbSet<RoleMapping> roleMappings { get; set; }
        public DbSet<Cart> carts { get; set; }

    }
}
