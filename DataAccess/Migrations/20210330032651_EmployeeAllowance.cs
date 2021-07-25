using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAccess.Migrations
{
    public partial class EmployeeAllowance : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AllowanceEmployee");

            migrationBuilder.AddColumn<int>(
                name: "AllowanceId",
                table: "Employee",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "EmployeeVsAllowance",
                columns: table => new
                {
                    EmployeeId = table.Column<int>(type: "int", nullable: false),
                    AllowanceId = table.Column<int>(type: "int", nullable: false),
                    DepartmentId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmployeeVsAllowance", x => new { x.EmployeeId, x.AllowanceId });
                    table.ForeignKey(
                        name: "FK_EmployeeVsAllowance_Allowance_AllowanceId",
                        column: x => x.AllowanceId,
                        principalTable: "Allowance",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EmployeeVsAllowance_Department_DepartmentId",
                        column: x => x.DepartmentId,
                        principalTable: "Department",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_EmployeeVsAllowance_Employee_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "Employee",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Employee_AllowanceId",
                table: "Employee",
                column: "AllowanceId");

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeVsAllowance_AllowanceId",
                table: "EmployeeVsAllowance",
                column: "AllowanceId");

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeVsAllowance_DepartmentId",
                table: "EmployeeVsAllowance",
                column: "DepartmentId");

            migrationBuilder.AddForeignKey(
                name: "FK_Employee_Allowance_AllowanceId",
                table: "Employee",
                column: "AllowanceId",
                principalTable: "Allowance",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Employee_Allowance_AllowanceId",
                table: "Employee");

            migrationBuilder.DropTable(
                name: "EmployeeVsAllowance");

            migrationBuilder.DropIndex(
                name: "IX_Employee_AllowanceId",
                table: "Employee");

            migrationBuilder.DropColumn(
                name: "AllowanceId",
                table: "Employee");

            migrationBuilder.CreateTable(
                name: "AllowanceEmployee",
                columns: table => new
                {
                    AllowanceId = table.Column<int>(type: "int", nullable: false),
                    EmployeeId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AllowanceEmployee", x => new { x.AllowanceId, x.EmployeeId });
                    table.ForeignKey(
                        name: "FK_AllowanceEmployee_Allowance_AllowanceId",
                        column: x => x.AllowanceId,
                        principalTable: "Allowance",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AllowanceEmployee_Employee_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "Employee",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AllowanceEmployee_EmployeeId",
                table: "AllowanceEmployee",
                column: "EmployeeId");
        }
    }
}
