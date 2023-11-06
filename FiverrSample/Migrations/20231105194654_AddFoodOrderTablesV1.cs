using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Fiverr_Sample.Migrations
{
    public partial class AddFoodOrderTablesV1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "FoodOrderStatusList",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StatusName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FoodOrderStatusList", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Product",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Product", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "FoodOrder",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TotalPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    FoodOrderLineItemOrderId = table.Column<int>(type: "int", nullable: true),
                    FoodOrderLineItemProductId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FoodOrder", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "FoodOrderLineItem",
                columns: table => new
                {
                    OrderId = table.Column<int>(type: "int", nullable: false),
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Quantity = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    StatusId = table.Column<int>(type: "int", nullable: false),
                    FoodOrderStatusListId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FoodOrderLineItem", x => new { x.OrderId, x.ProductId });
                    table.ForeignKey(
                        name: "FK_FoodOrderLineItem_FoodOrder_OrderId",
                        column: x => x.OrderId,
                        principalTable: "FoodOrder",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FoodOrderLineItem_FoodOrderStatusList_FoodOrderStatusListId",
                        column: x => x.FoodOrderStatusListId,
                        principalTable: "FoodOrderStatusList",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_FoodOrderLineItem_Product_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Product",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_FoodOrder_FoodOrderLineItemOrderId_FoodOrderLineItemProductId",
                table: "FoodOrder",
                columns: new[] { "FoodOrderLineItemOrderId", "FoodOrderLineItemProductId" });

            migrationBuilder.CreateIndex(
                name: "IX_FoodOrderLineItem_FoodOrderStatusListId",
                table: "FoodOrderLineItem",
                column: "FoodOrderStatusListId");

            migrationBuilder.CreateIndex(
                name: "IX_FoodOrderLineItem_ProductId",
                table: "FoodOrderLineItem",
                column: "ProductId");

            migrationBuilder.AddForeignKey(
                name: "FK_FoodOrder_FoodOrderLineItem_FoodOrderLineItemOrderId_FoodOrderLineItemProductId",
                table: "FoodOrder",
                columns: new[] { "FoodOrderLineItemOrderId", "FoodOrderLineItemProductId" },
                principalTable: "FoodOrderLineItem",
                principalColumns: new[] { "OrderId", "ProductId" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FoodOrder_FoodOrderLineItem_FoodOrderLineItemOrderId_FoodOrderLineItemProductId",
                table: "FoodOrder");

            migrationBuilder.DropTable(
                name: "FoodOrderLineItem");

            migrationBuilder.DropTable(
                name: "FoodOrder");

            migrationBuilder.DropTable(
                name: "FoodOrderStatusList");

            migrationBuilder.DropTable(
                name: "Product");
        }
    }
}
