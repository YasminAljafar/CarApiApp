using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CarApiApp.Migrations
{
    /// <inheritdoc />
    public partial class SeedingInitData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Cars",
                columns: new[] { "Id", "Gear", "Km", "Model", "Year" },
                values: new object[] { 1, 3, 5.0, "2023", 2023 });

            migrationBuilder.InsertData(
                table: "Suppliers",
                columns: new[] { "Id", "Address", "Name" },
                values: new object[] { 1, "Idlib/Syria", "Yasmin" });

            migrationBuilder.InsertData(
                table: "Parts",
                columns: new[] { "Id", "Name", "Price", "Quantity", "SupplierId" },
                values: new object[] { 2, "Moo", 90.0, 9, 1 });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Parts",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Suppliers",
                keyColumn: "Id",
                keyValue: 1);
        }
    }
}
