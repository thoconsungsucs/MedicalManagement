using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace DataAccessLayer.Migrations
{
    /// <inheritdoc />
    public partial class SeedRoles : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "2c3ddc4c-28f8-4c09-9a5e-2da36d0693bf", null, "Admin", "ADMIN" },
                    { "69aae601-07ac-4bb4-b575-55397e77f80a", null, "Patient", "PATIENT" },
                    { "ca675e7e-f57c-4bd1-ae2e-be1908c6adfa", null, "Doctor", "DOCTOR" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2c3ddc4c-28f8-4c09-9a5e-2da36d0693bf");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "69aae601-07ac-4bb4-b575-55397e77f80a");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ca675e7e-f57c-4bd1-ae2e-be1908c6adfa");
        }
    }
}
