using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Fiverr_Sample.Migrations
{
    public partial class AddRelevantTblInContext : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FoodOrder_FoodOrderLineItem_FoodOrderLineItemOrderId_FoodOrderLineItemProductId",
                table: "FoodOrder");

            migrationBuilder.DropForeignKey(
                name: "FK_FoodOrderLineItem_FoodOrder_OrderId",
                table: "FoodOrderLineItem");

            migrationBuilder.DropForeignKey(
                name: "FK_FoodOrderLineItem_FoodOrderStatusList_FoodOrderStatusListId",
                table: "FoodOrderLineItem");

            migrationBuilder.DropForeignKey(
                name: "FK_FoodOrderLineItem_Product_ProductId",
                table: "FoodOrderLineItem");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Product",
                table: "Product");

            migrationBuilder.DropPrimaryKey(
                name: "PK_FoodOrderStatusList",
                table: "FoodOrderStatusList");

            migrationBuilder.DropPrimaryKey(
                name: "PK_FoodOrderLineItem",
                table: "FoodOrderLineItem");

            migrationBuilder.DropPrimaryKey(
                name: "PK_FoodOrder",
                table: "FoodOrder");

            migrationBuilder.RenameTable(
                name: "Product",
                newName: "Products");

            migrationBuilder.RenameTable(
                name: "FoodOrderStatusList",
                newName: "FoodOrderStatusLists");

            migrationBuilder.RenameTable(
                name: "FoodOrderLineItem",
                newName: "FoodOrderLineItems");

            migrationBuilder.RenameTable(
                name: "FoodOrder",
                newName: "FoodOrders");

            migrationBuilder.RenameIndex(
                name: "IX_FoodOrderLineItem_ProductId",
                table: "FoodOrderLineItems",
                newName: "IX_FoodOrderLineItems_ProductId");

            migrationBuilder.RenameIndex(
                name: "IX_FoodOrderLineItem_FoodOrderStatusListId",
                table: "FoodOrderLineItems",
                newName: "IX_FoodOrderLineItems_FoodOrderStatusListId");

            migrationBuilder.RenameIndex(
                name: "IX_FoodOrder_FoodOrderLineItemOrderId_FoodOrderLineItemProductId",
                table: "FoodOrders",
                newName: "IX_FoodOrders_FoodOrderLineItemOrderId_FoodOrderLineItemProductId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Products",
                table: "Products",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_FoodOrderStatusLists",
                table: "FoodOrderStatusLists",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_FoodOrderLineItems",
                table: "FoodOrderLineItems",
                columns: new[] { "OrderId", "ProductId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_FoodOrders",
                table: "FoodOrders",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_FoodOrderLineItems_FoodOrders_OrderId",
                table: "FoodOrderLineItems",
                column: "OrderId",
                principalTable: "FoodOrders",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_FoodOrderLineItems_FoodOrderStatusLists_FoodOrderStatusListId",
                table: "FoodOrderLineItems",
                column: "FoodOrderStatusListId",
                principalTable: "FoodOrderStatusLists",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_FoodOrderLineItems_Products_ProductId",
                table: "FoodOrderLineItems",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_FoodOrders_FoodOrderLineItems_FoodOrderLineItemOrderId_FoodOrderLineItemProductId",
                table: "FoodOrders",
                columns: new[] { "FoodOrderLineItemOrderId", "FoodOrderLineItemProductId" },
                principalTable: "FoodOrderLineItems",
                principalColumns: new[] { "OrderId", "ProductId" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FoodOrderLineItems_FoodOrders_OrderId",
                table: "FoodOrderLineItems");

            migrationBuilder.DropForeignKey(
                name: "FK_FoodOrderLineItems_FoodOrderStatusLists_FoodOrderStatusListId",
                table: "FoodOrderLineItems");

            migrationBuilder.DropForeignKey(
                name: "FK_FoodOrderLineItems_Products_ProductId",
                table: "FoodOrderLineItems");

            migrationBuilder.DropForeignKey(
                name: "FK_FoodOrders_FoodOrderLineItems_FoodOrderLineItemOrderId_FoodOrderLineItemProductId",
                table: "FoodOrders");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Products",
                table: "Products");

            migrationBuilder.DropPrimaryKey(
                name: "PK_FoodOrderStatusLists",
                table: "FoodOrderStatusLists");

            migrationBuilder.DropPrimaryKey(
                name: "PK_FoodOrders",
                table: "FoodOrders");

            migrationBuilder.DropPrimaryKey(
                name: "PK_FoodOrderLineItems",
                table: "FoodOrderLineItems");

            migrationBuilder.RenameTable(
                name: "Products",
                newName: "Product");

            migrationBuilder.RenameTable(
                name: "FoodOrderStatusLists",
                newName: "FoodOrderStatusList");

            migrationBuilder.RenameTable(
                name: "FoodOrders",
                newName: "FoodOrder");

            migrationBuilder.RenameTable(
                name: "FoodOrderLineItems",
                newName: "FoodOrderLineItem");

            migrationBuilder.RenameIndex(
                name: "IX_FoodOrders_FoodOrderLineItemOrderId_FoodOrderLineItemProductId",
                table: "FoodOrder",
                newName: "IX_FoodOrder_FoodOrderLineItemOrderId_FoodOrderLineItemProductId");

            migrationBuilder.RenameIndex(
                name: "IX_FoodOrderLineItems_ProductId",
                table: "FoodOrderLineItem",
                newName: "IX_FoodOrderLineItem_ProductId");

            migrationBuilder.RenameIndex(
                name: "IX_FoodOrderLineItems_FoodOrderStatusListId",
                table: "FoodOrderLineItem",
                newName: "IX_FoodOrderLineItem_FoodOrderStatusListId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Product",
                table: "Product",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_FoodOrderStatusList",
                table: "FoodOrderStatusList",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_FoodOrder",
                table: "FoodOrder",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_FoodOrderLineItem",
                table: "FoodOrderLineItem",
                columns: new[] { "OrderId", "ProductId" });

            migrationBuilder.AddForeignKey(
                name: "FK_FoodOrder_FoodOrderLineItem_FoodOrderLineItemOrderId_FoodOrderLineItemProductId",
                table: "FoodOrder",
                columns: new[] { "FoodOrderLineItemOrderId", "FoodOrderLineItemProductId" },
                principalTable: "FoodOrderLineItem",
                principalColumns: new[] { "OrderId", "ProductId" });

            migrationBuilder.AddForeignKey(
                name: "FK_FoodOrderLineItem_FoodOrder_OrderId",
                table: "FoodOrderLineItem",
                column: "OrderId",
                principalTable: "FoodOrder",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_FoodOrderLineItem_FoodOrderStatusList_FoodOrderStatusListId",
                table: "FoodOrderLineItem",
                column: "FoodOrderStatusListId",
                principalTable: "FoodOrderStatusList",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_FoodOrderLineItem_Product_ProductId",
                table: "FoodOrderLineItem",
                column: "ProductId",
                principalTable: "Product",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
