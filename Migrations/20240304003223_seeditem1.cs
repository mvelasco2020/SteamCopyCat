using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SteamCopyCat.Migrations
{
    /// <inheritdoc />
    public partial class seeditem1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "MenuItems",
                columns: new[] { "Id", "Calories", "CategoryId", "Description", "Image", "Name", "Price" },
                values: new object[] { 1, 469, 1, "The McDonald's Bacon, Egg & Cheese Biscuit breakfast sandwich features a warm, buttermilk biscuit brushed with real butter, thick cut Applewood smoked bacon, a fluffy folded egg, and a slice of melty American cheese. There are 460 calories in a Bacon, Egg & Cheese Biscuit at McDonald's. Try one today with a Premium Roast Coffee and order with Mobile Order & Pay on the McDonald's App!\r\n\r\nDownload the McDonald’s app and earn points on every order with MyMcDonald's Rewards to redeem for a free Bacon, Egg & Cheese Biscuit.", null, "Bacon, Egg & Cheese Biscuit", 1.99 });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: 1);
        }
    }
}
