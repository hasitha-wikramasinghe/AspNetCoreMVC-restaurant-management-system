using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Fiverr_Sample.Migrations
{
    public partial class ProductCodeAdd : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ProductCode",
                table: "Product",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ProductCode",
                table: "Product");
        }
    }
}
