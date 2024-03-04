using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SteamCopyCat.Migrations
{
    /// <inheritdoc />
    public partial class updaterefernece : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Ingredient_MenuItems_MenuItemId",
                table: "Ingredient");

            migrationBuilder.DropIndex(
                name: "IX_Ingredient_MenuItemId",
                table: "Ingredient");

            migrationBuilder.DropColumn(
                name: "MenuItemId",
                table: "Ingredient");

            migrationBuilder.AddColumn<int>(
                name: "IngredientsId",
                table: "MenuItems",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "IngredientMenuItem",
                columns: table => new
                {
                    IngredientsId = table.Column<int>(type: "int", nullable: false),
                    MenuItemsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IngredientMenuItem", x => new { x.IngredientsId, x.MenuItemsId });
                    table.ForeignKey(
                        name: "FK_IngredientMenuItem_Ingredient_IngredientsId",
                        column: x => x.IngredientsId,
                        principalTable: "Ingredient",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_IngredientMenuItem_MenuItems_MenuItemsId",
                        column: x => x.MenuItemsId,
                        principalTable: "MenuItems",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_IngredientMenuItem_MenuItemsId",
                table: "IngredientMenuItem",
                column: "MenuItemsId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "IngredientMenuItem");

            migrationBuilder.DropColumn(
                name: "IngredientsId",
                table: "MenuItems");

            migrationBuilder.AddColumn<int>(
                name: "MenuItemId",
                table: "Ingredient",
                type: "int",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Ingredient",
                keyColumn: "Id",
                keyValue: 1,
                column: "MenuItemId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Ingredient",
                keyColumn: "Id",
                keyValue: 2,
                column: "MenuItemId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Ingredient",
                keyColumn: "Id",
                keyValue: 3,
                column: "MenuItemId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Ingredient",
                keyColumn: "Id",
                keyValue: 4,
                column: "MenuItemId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Ingredient",
                keyColumn: "Id",
                keyValue: 5,
                column: "MenuItemId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Ingredient",
                keyColumn: "Id",
                keyValue: 6,
                column: "MenuItemId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Ingredient",
                keyColumn: "Id",
                keyValue: 7,
                column: "MenuItemId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Ingredient",
                keyColumn: "Id",
                keyValue: 8,
                column: "MenuItemId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Ingredient",
                keyColumn: "Id",
                keyValue: 9,
                column: "MenuItemId",
                value: null);

            migrationBuilder.CreateIndex(
                name: "IX_Ingredient_MenuItemId",
                table: "Ingredient",
                column: "MenuItemId");

            migrationBuilder.AddForeignKey(
                name: "FK_Ingredient_MenuItems_MenuItemId",
                table: "Ingredient",
                column: "MenuItemId",
                principalTable: "MenuItems",
                principalColumn: "Id");
        }
    }
}
