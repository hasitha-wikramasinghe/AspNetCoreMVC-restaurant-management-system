using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Fiverr_Sample.Migrations
{
    public partial class InsertFoodOrderStatus : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            string foodOrderStatusListInsertQuery = "INSERT INTO [dbo].[FoodOrderStatus]" +
                        "([StatusName],[StatusDescription],[CreatedBy],[CreatedOn],[ModifiedBy],[ModifiedOn])" +
                        "VALUES" +
                        "('KOT Pending','KOT Pending',null, null, null, null)," +
                        "('KOT Ready','KOT Ready',null, null, null, null)," +
                        "('Served','Served',null, null, null, null)," +
                        "('Completed','Completed',null, null, null, null)," +
                        "('Cancelled','Cancelled',null, null, null, null);";

            migrationBuilder.Sql(foodOrderStatusListInsertQuery);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
