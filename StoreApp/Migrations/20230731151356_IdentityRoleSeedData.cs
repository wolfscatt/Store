using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace StoreApp.Migrations
{
    /// <inheritdoc />
    public partial class IdentityRoleSeedData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "0c146506-a8c4-4ee7-88f7-dccef3b3bb00", null, "Admin", "ADMIN" },
                    { "6bf23528-6b4d-43f1-914a-e0a4d88d8b1c", null, "Editor", "EDITOR" },
                    { "7d38c2e2-754c-4ec1-b518-6d9827ce4b61", null, "User", "USER" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "0c146506-a8c4-4ee7-88f7-dccef3b3bb00");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "6bf23528-6b4d-43f1-914a-e0a4d88d8b1c");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "7d38c2e2-754c-4ec1-b518-6d9827ce4b61");
        }
    }
}
