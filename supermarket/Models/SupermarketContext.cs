using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace supermarket.Models
{
    public partial class SupermarketContext : DbContext
    {
        public SupermarketContext() : base(GetConnectionString())
        {
            Database.SetInitializer<SupermarketContext>(new CreateDatabaseIfNotExists<SupermarketContext>());
        }

        public static string GetConnectionString()
        {
            return ConfigurationManager.ConnectionStrings["SupermarketContext"].ToString();
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Order> Orders { get; set; }
    }
}