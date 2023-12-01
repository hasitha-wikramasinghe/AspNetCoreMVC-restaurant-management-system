using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Fiverr_Sample.Migrations
{
    public partial class InsertFoodOrderType : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            string foodOrderTypesListInsertQuery = "INSERT INTO [dbo].[FoodOrderType]" +
                        "([OrderTypeName],[OrderTypeDescription])" +
                        "VALUES" +
                        "('Dine In','Dine In')," +
                        "('Take Away','Take Away')," +
                        "('Online Order','Online Order');";

            migrationBuilder.Sql(foodOrderTypesListInsertQuery);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
