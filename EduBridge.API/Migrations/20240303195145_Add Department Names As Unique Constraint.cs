using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace EduBridge.API.Migrations
{
    /// <inheritdoc />
    public partial class AddDepartmentNamesAsUniqueConstraint : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "0e58fda8-334a-4976-9b97-475617ed3c9c");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2972980c-8d94-425b-a460-da59be89d7d9");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "aefc3fb7-a56a-444a-9826-239319ca7d0b");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d9b3acbf-f0f8-4740-a3f6-f004e2acc928");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Courses",
                newName: "Unit");

            migrationBuilder.AddColumn<string>(
                name: "Type",
                table: "Rooms",
                type: "longtext",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "ShortName",
                table: "Departments",
                type: "varchar(255)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "longtext");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Departments",
                type: "varchar(255)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "longtext");

            migrationBuilder.AlterColumn<string>(
                name: "Title",
                table: "Courses",
                type: "varchar(255)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "longtext");

            migrationBuilder.AlterColumn<string>(
                name: "Code",
                table: "Courses",
                type: "varchar(255)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "longtext");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "432a1d9c-8357-43ce-be3a-5e4d49a6dd6c", null, "Student", "STUDENT" },
                    { "52c075b0-d88e-425e-8ebe-504af1a05545", null, "Administrator", "ADMINISTRATOR" },
                    { "d9ece725-7a59-44ce-a797-47dd264fcc86", null, "User", "USER" },
                    { "f2b0fd3e-3d8c-4058-a0fc-79c61922af91", null, "Teacher", "TEACHER" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Departments_Name_ShortName",
                table: "Departments",
                columns: new[] { "Name", "ShortName" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Courses_Title_Code",
                table: "Courses",
                columns: new[] { "Title", "Code" },
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Departments_Name_ShortName",
                table: "Departments");

            migrationBuilder.DropIndex(
                name: "IX_Courses_Title_Code",
                table: "Courses");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "432a1d9c-8357-43ce-be3a-5e4d49a6dd6c");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "52c075b0-d88e-425e-8ebe-504af1a05545");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d9ece725-7a59-44ce-a797-47dd264fcc86");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "f2b0fd3e-3d8c-4058-a0fc-79c61922af91");

            migrationBuilder.DropColumn(
                name: "Type",
                table: "Rooms");

            migrationBuilder.RenameColumn(
                name: "Unit",
                table: "Courses",
                newName: "Name");

            migrationBuilder.AlterColumn<string>(
                name: "ShortName",
                table: "Departments",
                type: "longtext",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(255)");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Departments",
                type: "longtext",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(255)");

            migrationBuilder.AlterColumn<string>(
                name: "Title",
                table: "Courses",
                type: "longtext",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(255)");

            migrationBuilder.AlterColumn<string>(
                name: "Code",
                table: "Courses",
                type: "longtext",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(255)");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "0e58fda8-334a-4976-9b97-475617ed3c9c", null, "Student", "STUDENT" },
                    { "2972980c-8d94-425b-a460-da59be89d7d9", null, "User", "USER" },
                    { "aefc3fb7-a56a-444a-9826-239319ca7d0b", null, "Teacher", "TEACHER" },
                    { "d9b3acbf-f0f8-4740-a3f6-f004e2acc928", null, "Administrator", "ADMINISTRATOR" }
                });
        }
    }
}
