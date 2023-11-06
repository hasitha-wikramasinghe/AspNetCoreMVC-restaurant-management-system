using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Fiverr_Sample.Migrations
{
    public partial class InsertFoodOrderStatusList : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            string foodOrderStatusListInsertQuery = "INSERT INTO [dbo].[FoodOrderStatusLists]" +
                        "([StatusName],[StatusDescription],[CreatedBy],[CreatedOn],[ModifiedBy],[ModifiedOn])" +
                        "VALUES" +
                        "('Created','Created',null, null, null, null)," +
                        "('In Progress','In Progress',null, null, null, null)," +
                        "('Completed','Completed',null, null, null, null)," +
                        "('Cancelled','Cancelled',null, null, null, null);";

            migrationBuilder.Sql(foodOrderStatusListInsertQuery);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
