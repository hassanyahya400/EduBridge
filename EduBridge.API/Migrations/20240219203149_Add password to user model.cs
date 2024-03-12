using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace EduBridge.API.Migrations
{
    /// <inheritdoc />
    public partial class Addpasswordtousermodel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "037a594a-888d-4b26-b615-7bde625414c0");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "153a6050-1ec9-42ea-baad-a048cbdae487");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "20c7f668-45bf-4e35-b169-8723ba5f47cd");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a6c0110f-d9b6-449a-87de-516142b9a035");

            migrationBuilder.AddColumn<string>(
                name: "Password",
                table: "AspNetUsers",
                type: "varchar(15)",
                maxLength: 15,
                nullable: false,
                defaultValue: "");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "379978f9-cffb-48fe-9826-4b4486cf201e", null, "User", "USER" },
                    { "b1cdd294-f7b4-4e67-8fae-52e2f20337b4", null, "Student", "STUDENT" },
                    { "bd1d6b43-470b-4c15-9d8d-ae53eedb2d90", null, "Administrator", "ADMINISTRATOR" },
                    { "c98ad570-5588-42cd-9839-cabef54cb3c4", null, "Lecturer", "LECTURER" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "379978f9-cffb-48fe-9826-4b4486cf201e");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b1cdd294-f7b4-4e67-8fae-52e2f20337b4");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "bd1d6b43-470b-4c15-9d8d-ae53eedb2d90");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c98ad570-5588-42cd-9839-cabef54cb3c4");

            migrationBuilder.DropColumn(
                name: "Password",
                table: "AspNetUsers");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "037a594a-888d-4b26-b615-7bde625414c0", null, "Lecturer", "LECTURER" },
                    { "153a6050-1ec9-42ea-baad-a048cbdae487", null, "Administrator", "ADMINISTRATOR" },
                    { "20c7f668-45bf-4e35-b169-8723ba5f47cd", null, "Student", "STUDENT" },
                    { "a6c0110f-d9b6-449a-87de-516142b9a035", null, "User", "USER" }
                });
        }
    }
}
