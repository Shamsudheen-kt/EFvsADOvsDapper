using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAccess.Migrations
{
    public partial class DemoStored_Remove : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FullName",
                table: "Employee");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "FullName",
                table: "Employee",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: true,
                computedColumnSql: "LEN([LastName]) + LEN([FirstName])",
                stored: true);
        }
    }
}
