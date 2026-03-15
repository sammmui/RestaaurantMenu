using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RestaurantMenuInfrastructure.Migrations
{
    public partial class AddPriceOnly : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            // Ми видалили CreateTable для всіх таблиць і залишили тільки це:
            migrationBuilder.AddColumn<decimal>(
                name: "price",
                table: "PRODUCTS",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            // Відкат зміни: просто видаляємо колонку назад
            migrationBuilder.DropColumn(
                name: "price",
                table: "PRODUCTS");
        }
    }
}