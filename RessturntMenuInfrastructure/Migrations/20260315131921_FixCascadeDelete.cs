using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RestaurantMenuInfrastructure.Migrations
{
    /// <inheritdoc />
    public partial class FixCascadeDelete : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PRODUCT DISCOUNTS_PRODUCTS",
                table: "PRODUCT DISCOUNTS");

            migrationBuilder.DropForeignKey(
                name: "FK_PRODUCTS_CATEGORIES",
                table: "PRODUCTS");

            migrationBuilder.AddForeignKey(
                name: "FK_PRODUCT DISCOUNTS_PRODUCTS",
                table: "PRODUCT DISCOUNTS",
                column: "Productsid",
                principalTable: "PRODUCTS",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PRODUCTS_CATEGORIES",
                table: "PRODUCTS",
                column: "Categoriesid",
                principalTable: "CATEGORIES",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PRODUCT DISCOUNTS_PRODUCTS",
                table: "PRODUCT DISCOUNTS");

            migrationBuilder.DropForeignKey(
                name: "FK_PRODUCTS_CATEGORIES",
                table: "PRODUCTS");

            migrationBuilder.AddForeignKey(
                name: "FK_PRODUCT DISCOUNTS_PRODUCTS",
                table: "PRODUCT DISCOUNTS",
                column: "Productsid",
                principalTable: "PRODUCTS",
                principalColumn: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_PRODUCTS_CATEGORIES",
                table: "PRODUCTS",
                column: "Categoriesid",
                principalTable: "CATEGORIES",
                principalColumn: "id");
        }
    }
}
