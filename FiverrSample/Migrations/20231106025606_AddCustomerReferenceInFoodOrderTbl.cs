using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Fiverr_Sample.Migrations
{
    public partial class AddCustomerReferenceInFoodOrderTbl : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "Products",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedOn",
                table: "Products",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ModifiedBy",
                table: "Products",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "ModifiedOn",
                table: "Products",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "FoodOrderStatusLists",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedOn",
                table: "FoodOrderStatusLists",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ModifiedBy",
                table: "FoodOrderStatusLists",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "ModifiedOn",
                table: "FoodOrderStatusLists",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "FoodOrders",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedOn",
                table: "FoodOrders",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CustomerId",
                table: "FoodOrders",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ModifiedBy",
                table: "FoodOrders",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "ModifiedOn",
                table: "FoodOrders",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "FoodOrderLineItems",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedOn",
                table: "FoodOrderLineItems",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ModifiedBy",
                table: "FoodOrderLineItems",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "ModifiedOn",
                table: "FoodOrderLineItems",
                type: "datetime2",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Customer",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NIC = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PhoneNumber = table.Column<int>(type: "int", nullable: false),
                    OrdersCompleted = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customer", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_FoodOrders_CustomerId",
                table: "FoodOrders",
                column: "CustomerId");

            migrationBuilder.AddForeignKey(
                name: "FK_FoodOrders_Customer_CustomerId",
                table: "FoodOrders",
                column: "CustomerId",
                principalTable: "Customer",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FoodOrders_Customer_CustomerId",
                table: "FoodOrders");

            migrationBuilder.DropTable(
                name: "Customer");

            migrationBuilder.DropIndex(
                name: "IX_FoodOrders_CustomerId",
                table: "FoodOrders");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "CreatedOn",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "ModifiedBy",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "ModifiedOn",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "FoodOrderStatusLists");

            migrationBuilder.DropColumn(
                name: "CreatedOn",
                table: "FoodOrderStatusLists");

            migrationBuilder.DropColumn(
                name: "ModifiedBy",
                table: "FoodOrderStatusLists");

            migrationBuilder.DropColumn(
                name: "ModifiedOn",
                table: "FoodOrderStatusLists");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "FoodOrders");

            migrationBuilder.DropColumn(
                name: "CreatedOn",
                table: "FoodOrders");

            migrationBuilder.DropColumn(
                name: "CustomerId",
                table: "FoodOrders");

            migrationBuilder.DropColumn(
                name: "ModifiedBy",
                table: "FoodOrders");

            migrationBuilder.DropColumn(
                name: "ModifiedOn",
                table: "FoodOrders");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "FoodOrderLineItems");

            migrationBuilder.DropColumn(
                name: "CreatedOn",
                table: "FoodOrderLineItems");

            migrationBuilder.DropColumn(
                name: "ModifiedBy",
                table: "FoodOrderLineItems");

            migrationBuilder.DropColumn(
                name: "ModifiedOn",
                table: "FoodOrderLineItems");
        }
    }
}
