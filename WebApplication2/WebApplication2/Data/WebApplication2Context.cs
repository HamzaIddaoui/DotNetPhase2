using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WebApplication2.Models;

namespace WebApplication2.Data
{
    public class WebApplication2Context : DbContext
    {
        public WebApplication2Context (DbContextOptions<WebApplication2Context> options)
            : base(options)
        {
        }

        public DbSet<WebApplication2.Models.Product> Product { get; set; } = default!;


        public DbSet<WebApplication2.Models.Cart> Cart { get; set; } = default!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Cart>()
                .HasMany(c => c.cartItems)
                .WithOne(c => c.Cart)
                .HasForeignKey(c => c.Cart_Id)
                .HasPrincipalKey(c => c.Id);
            modelBuilder.Entity<Product>()
                .HasMany(c => c.CartItems)
                .WithOne(c => c.Product)
                .HasForeignKey(c => c.Product_Id)
                .HasPrincipalKey(c => c.Id);           
        }

        public DbSet<WebApplication2.Models.CartItem> CartItem { get; set; } = default!;
    }
}
