using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SteamCopyCat.Models;

namespace SteamCopyCat.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {

        public ApplicationDbContext(DbContextOptions options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Entity<Ingredient>().HasData(
                new Ingredient
                {
                    Id = 1,
                    Name = "Biscuit"
                }, new Ingredient
                {
                    Id = 2,
                    Name = "Folded Egg"
                }, new Ingredient
                {
                    Id = 3,
                    Name = "Pasteurized Process American Cheese"
                }, new Ingredient
                {
                    Id = 4,
                    Name = "Thick Cut Applewood Smoked Bacon"
                }, new Ingredient
                {
                    Id = 5,
                    Name = "Salted Butter"
                }, new Ingredient
                {
                    Id = 6,
                    Name = "Clarified Butter"
                }
                , new Ingredient
                {
                    Id = 7,
                    Name = "English Muffin"
                }, new Ingredient
                {
                    Id = 8,
                    Name = "Egg"
                }, new Ingredient
                {
                    Id = 9,
                    Name = "Canadian Bacon"
                });

            builder.Entity<Category>().HasData(new Category
            {
                Id = 1,
                Name = "Breakfast"
            });


            builder.Entity<MenuItem>().HasData(
                new MenuItem
                {
                    Id = 1,
                    Name = "Bacon, Egg & Cheese Biscuit",
                    Description = "The McDonald's Bacon, Egg & Cheese Biscuit breakfast sandwich features a warm, buttermilk biscuit brushed with real butter, thick cut Applewood smoked bacon, a fluffy folded egg, and a slice of melty American cheese. There are 460 calories in a Bacon, Egg & Cheese Biscuit at McDonald's. Try one today with a Premium Roast Coffee and order with Mobile Order & Pay on the McDonald's App!\r\n\r\nDownload the McDonald’s app and earn points on every order with MyMcDonald's Rewards to redeem for a free Bacon, Egg & Cheese Biscuit.",
                    Calories = 469,
                    CategoryId = 1,
                    Price = 1.99,
                });

        }
        public DbSet<ApplicationUser> ApplicationUsers { get; set; }

        public DbSet<MenuItem> MenuItems { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Ingredient> Ingredients { get; set; }

    }


}
