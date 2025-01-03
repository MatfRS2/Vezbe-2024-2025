using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace IdentityServer.Migrations
{
    /// <inheritdoc />
    public partial class ConnectedRefreshTokensToUsers : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2fa0f46e-3ba9-4b54-a2ba-cd4868c195cb");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "64e10e2a-6cbd-4628-a49c-0d566d6a6188");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "bbf2266a-b2d1-4d9e-b1f5-2695a4ea5145", null, "Administrator", "ADMINISTRATOR" },
                    { "c3220988-239e-46d8-beb5-001ba8b6ef3a", null, "Buyer", "BUYER" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "bbf2266a-b2d1-4d9e-b1f5-2695a4ea5145");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c3220988-239e-46d8-beb5-001ba8b6ef3a");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "2fa0f46e-3ba9-4b54-a2ba-cd4868c195cb", null, "Buyer", "BUYER" },
                    { "64e10e2a-6cbd-4628-a49c-0d566d6a6188", null, "Administrator", "ADMINISTRATOR" }
                });
        }
    }
}
