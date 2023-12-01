using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Fiverr_Sample.Migrations
{
    public partial class MakePhoneNumberUniqueInCustomer : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            var createUniqueIndexQuery = "CREATE UNIQUE INDEX IX_Customer_PhoneNumber ON [dbo].[Customer] (PhoneNumber)";
            migrationBuilder.Sql(createUniqueIndexQuery);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            var deleteUniqueIndexQuery = "DROP INDEX IX_Customer_PhoneNumber ON [dbo].[Customer]";
            migrationBuilder.Sql(deleteUniqueIndexQuery);
        }
    }
}
