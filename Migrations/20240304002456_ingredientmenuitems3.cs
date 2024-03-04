using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SteamCopyCat.Migrations
{
    /// <inheritdoc />
    public partial class ingredientmenuitems3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IngredientsId",
                table: "MenuItems");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "IngredientsId",
                table: "MenuItems",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
