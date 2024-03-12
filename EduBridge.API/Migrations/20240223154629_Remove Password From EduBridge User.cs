using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace EduBridge.API.Migrations
{
    /// <inheritdoc />
    public partial class RemovePasswordFromEduBridgeUser : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "174f70b0-0d29-4ac2-b37d-a106f2124d9d");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "68f50c91-c836-4352-a258-9e57c1f3d0d0");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e50e9146-5510-4228-a7a7-d53016a49441");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "f8241b5f-5ed8-4611-853c-bbb9b0619436");

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "174f70b0-0d29-4ac2-b37d-a106f2124d9d", null, "Student", "STUDENT" },
                    { "68f50c91-c836-4352-a258-9e57c1f3d0d0", null, "Administrator", "ADMINISTRATOR" },
                    { "e50e9146-5510-4228-a7a7-d53016a49441", null, "Lecturer", "LECTURER" },
                    { "f8241b5f-5ed8-4611-853c-bbb9b0619436", null, "User", "USER" }
                });
        }
    }
}
