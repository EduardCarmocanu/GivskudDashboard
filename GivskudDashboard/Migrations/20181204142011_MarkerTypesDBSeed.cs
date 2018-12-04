using Microsoft.EntityFrameworkCore.Migrations;

namespace GivskudDashboard.Migrations
{
    public partial class MarkerTypesDBSeed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "MarkerTypes",
                columns: new[] { "ID", "Name" },
                values: new object[,]
                {
                    { 1, "Animal" },
                    { 2, "Shop" },
                    { 3, "Accommodation" },
                    { 4, "Toilet" },
                    { 5, "Restaurant" },
                    { 6, "Playground" },
                    { 7, "Picknick" },
                    { 8, "Icecram" },
                    { 9, "Parking" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "MarkerTypes",
                keyColumn: "ID",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "MarkerTypes",
                keyColumn: "ID",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "MarkerTypes",
                keyColumn: "ID",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "MarkerTypes",
                keyColumn: "ID",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "MarkerTypes",
                keyColumn: "ID",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "MarkerTypes",
                keyColumn: "ID",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "MarkerTypes",
                keyColumn: "ID",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "MarkerTypes",
                keyColumn: "ID",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "MarkerTypes",
                keyColumn: "ID",
                keyValue: 9);
        }
    }
}
