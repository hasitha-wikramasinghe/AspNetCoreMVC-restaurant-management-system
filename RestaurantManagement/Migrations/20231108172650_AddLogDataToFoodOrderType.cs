using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Fiverr_Sample.Migrations
{
    public partial class AddLogDataToFoodOrderType : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "FoodOrderType",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedOn",
                table: "FoodOrderType",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ModifiedBy",
                table: "FoodOrderType",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "ModifiedOn",
                table: "FoodOrderType",
                type: "datetime2",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "FoodOrderType");

            migrationBuilder.DropColumn(
                name: "CreatedOn",
                table: "FoodOrderType");

            migrationBuilder.DropColumn(
                name: "ModifiedBy",
                table: "FoodOrderType");

            migrationBuilder.DropColumn(
                name: "ModifiedOn",
                table: "FoodOrderType");
        }
    }
}
