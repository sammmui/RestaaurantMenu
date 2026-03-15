using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RestaurantMenuInfrastructure.Migrations
{
    /// <inheritdoc />
    public partial class ChangeDeleteBehaviorToCascade : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_REVIEWS_PRODUCTS",
                table: "REVIEWS");

            migrationBuilder.AddForeignKey(
                name: "FK_REVIEWS_PRODUCTS_Productsid",
                table: "REVIEWS",
                column: "Productsid",
                principalTable: "PRODUCTS",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_REVIEWS_PRODUCTS_Productsid",
                table: "REVIEWS");

            migrationBuilder.AddForeignKey(
                name: "FK_REVIEWS_PRODUCTS",
                table: "REVIEWS",
                column: "Productsid",
                principalTable: "PRODUCTS",
                principalColumn: "id");
        }
    }
}
