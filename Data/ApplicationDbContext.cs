using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SteamCopyCat.Models;

namespace SteamCopyCat.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {

        public ApplicationDbContext(DbContextOptions options) : base(options) { }

        public DbSet<ApplicationUser> ApplicationUsers { get; set; }

        public DbSet<MenuItem> MenuItems { get; set; }


        //seed
        /*
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Entity<MenuItem>().HasData( 
                new MenuItem
                {
                    Id = 1,
                    Name = "Bacon, Egg & Cheese Biscuit",
                    Description = "The McDonald's Bacon, Egg & Cheese Biscuit breakfast sandwich features a warm, buttermilk biscuit brushed with real butter, thick cut Applewood smoked bacon, a fluffy folded egg, and a slice of melty American cheese. There are 460 calories in a Bacon, Egg & Cheese Biscuit at McDonald's. Try one today with a Premium Roast Coffee and order with Mobile Order & Pay on the McDonald's App!\r\n\r\nDownload the McDonald’s app and earn points on every order with MyMcDonald's Rewards to redeem for a free Bacon, Egg & Cheese Biscuit.",
                    Calories = 469,
                    Category = "Breakfast",
                    Price = 

                });
        }
         */
    }


}
