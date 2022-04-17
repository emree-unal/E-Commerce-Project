using Amazon.Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Amazon.DataAccess.Concrete.EntityFramework
{
    public class AmazonContext:DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=LAPTOP-4BSTRV6E\\SQLEXPRESS;initial catalog=Amazon; integrated security=true");
        }
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<User> Users { get; set; }





        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>().Property(x => x.ProductName).IsRequired();
            modelBuilder.Entity<Product>().HasOne(x => x.Category)
                                          .WithMany(x => x.Products)
                                          .HasForeignKey(x => x.CategoryId);
        }
    }
}
