using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAccess.Migrations
{
    public partial class EmployeeVsAllowanceCorrection : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Employee_Allowance_AllowanceId",
                table: "Employee");

            migrationBuilder.DropForeignKey(
                name: "FK_EmployeeVsAllowance_Department_DepartmentId",
                table: "EmployeeVsAllowance");

            migrationBuilder.DropIndex(
                name: "IX_EmployeeVsAllowance_DepartmentId",
                table: "EmployeeVsAllowance");

            migrationBuilder.DropIndex(
                name: "IX_Employee_AllowanceId",
                table: "Employee");

            migrationBuilder.DropColumn(
                name: "DepartmentId",
                table: "EmployeeVsAllowance");

            migrationBuilder.DropColumn(
                name: "AllowanceId",
                table: "Employee");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "DepartmentId",
                table: "EmployeeVsAllowance",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "AllowanceId",
                table: "Employee",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeVsAllowance_DepartmentId",
                table: "EmployeeVsAllowance",
                column: "DepartmentId");

            migrationBuilder.CreateIndex(
                name: "IX_Employee_AllowanceId",
                table: "Employee",
                column: "AllowanceId");

            migrationBuilder.AddForeignKey(
                name: "FK_Employee_Allowance_AllowanceId",
                table: "Employee",
                column: "AllowanceId",
                principalTable: "Allowance",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_EmployeeVsAllowance_Department_DepartmentId",
                table: "EmployeeVsAllowance",
                column: "DepartmentId",
                principalTable: "Department",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
