using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace EduBridge.API.Migrations
{
    /// <inheritdoc />
    public partial class addpasswordcolumntousermodel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "682dcd99-920c-4c93-89a3-aa69cb90a40f", null, "Administrator", "ADMINISTRATOR" },
                    { "a5e66f35-ac31-448d-a661-4d17238bf2c4", null, "Student", "STUDENT" },
                    { "b491a37e-2430-401e-af39-b43372c16dae", null, "User", "USER" },
                    { "f070e273-9440-4646-8b4a-e132d40f0f9b", null, "Lecturer", "LECTURER" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "682dcd99-920c-4c93-89a3-aa69cb90a40f");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a5e66f35-ac31-448d-a661-4d17238bf2c4");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b491a37e-2430-401e-af39-b43372c16dae");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "f070e273-9440-4646-8b4a-e132d40f0f9b");

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
    }
}
