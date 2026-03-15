using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RestaurantMenuInfrastructure.Migrations
{
    /// <inheritdoc />
    public partial class MigrationForProductImg : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Img",
                table: "PRODUCTS",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Img",
                table: "PRODUCTS");
        }
    }
}
