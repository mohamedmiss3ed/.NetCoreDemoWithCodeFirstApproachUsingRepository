using Microsoft.EntityFrameworkCore.Migrations;

namespace NetCoreLastLabDemoWithRepositoryAndCodeFirstApproach.Migrations
{
    public partial class second : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Courses_Department_DepartmentId",
                table: "Courses");

            migrationBuilder.AlterColumn<int>(
                name: "DepartmentId",
                table: "Courses",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Courses_Department_DepartmentId",
                table: "Courses",
                column: "DepartmentId",
                principalTable: "Department",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Courses_Department_DepartmentId",
                table: "Courses");

            migrationBuilder.AlterColumn<int>(
                name: "DepartmentId",
                table: "Courses",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Courses_Department_DepartmentId",
                table: "Courses",
                column: "DepartmentId",
                principalTable: "Department",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
