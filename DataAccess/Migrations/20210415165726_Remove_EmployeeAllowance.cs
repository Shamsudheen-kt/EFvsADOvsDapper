using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAccess.Migrations
{
    public partial class Remove_EmployeeAllowance : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EmployeeVsAllowance_Allowance_AllowanceId",
                table: "EmployeeVsAllowance");

            migrationBuilder.DropForeignKey(
                name: "FK_EmployeeVsAllowance_Employee_EmployeeId",
                table: "EmployeeVsAllowance");

            migrationBuilder.DropPrimaryKey(
                name: "PK_EmployeeVsAllowance",
                table: "EmployeeVsAllowance");

            migrationBuilder.RenameTable(
                name: "EmployeeVsAllowance",
                newName: "EmployeeAllowance");

            migrationBuilder.RenameIndex(
                name: "IX_EmployeeVsAllowance_AllowanceId",
                table: "EmployeeAllowance",
                newName: "IX_EmployeeAllowance_AllowanceId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_EmployeeAllowance",
                table: "EmployeeAllowance",
                columns: new[] { "EmployeeId", "AllowanceId" });

            migrationBuilder.AddForeignKey(
                name: "FK_EmployeeAllowance_Allowance_AllowanceId",
                table: "EmployeeAllowance",
                column: "AllowanceId",
                principalTable: "Allowance",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_EmployeeAllowance_Employee_EmployeeId",
                table: "EmployeeAllowance",
                column: "EmployeeId",
                principalTable: "Employee",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EmployeeAllowance_Allowance_AllowanceId",
                table: "EmployeeAllowance");

            migrationBuilder.DropForeignKey(
                name: "FK_EmployeeAllowance_Employee_EmployeeId",
                table: "EmployeeAllowance");

            migrationBuilder.DropPrimaryKey(
                name: "PK_EmployeeAllowance",
                table: "EmployeeAllowance");

            migrationBuilder.RenameTable(
                name: "EmployeeAllowance",
                newName: "EmployeeVsAllowance");

            migrationBuilder.RenameIndex(
                name: "IX_EmployeeAllowance_AllowanceId",
                table: "EmployeeVsAllowance",
                newName: "IX_EmployeeVsAllowance_AllowanceId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_EmployeeVsAllowance",
                table: "EmployeeVsAllowance",
                columns: new[] { "EmployeeId", "AllowanceId" });

            migrationBuilder.AddForeignKey(
                name: "FK_EmployeeVsAllowance_Allowance_AllowanceId",
                table: "EmployeeVsAllowance",
                column: "AllowanceId",
                principalTable: "Allowance",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_EmployeeVsAllowance_Employee_EmployeeId",
                table: "EmployeeVsAllowance",
                column: "EmployeeId",
                principalTable: "Employee",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
