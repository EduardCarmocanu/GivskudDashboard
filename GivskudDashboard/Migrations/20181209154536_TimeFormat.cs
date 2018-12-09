using Microsoft.EntityFrameworkCore.Migrations;

namespace GivskudDashboard.Migrations
{
    public partial class TimeFormat : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "MarkerTypes",
                keyColumn: "ID",
                keyValue: 8,
                column: "Name",
                value: "Icecream");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "MarkerTypes",
                keyColumn: "ID",
                keyValue: 8,
                column: "Name",
                value: "Icecram");
        }
    }
}
