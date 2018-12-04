using Microsoft.EntityFrameworkCore.Migrations;

namespace GivskudDashboard.Migrations
{
    public partial class DecimalPrecision : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<decimal>(
                name: "Lng",
                table: "Markers",
                type: "decimal(18, 15)",
                nullable: false,
                oldClrType: typeof(decimal));

            migrationBuilder.AlterColumn<decimal>(
                name: "Lat",
                table: "Markers",
                type: "decimal(18, 15)",
                nullable: false,
                oldClrType: typeof(decimal));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<decimal>(
                name: "Lng",
                table: "Markers",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18, 15)");

            migrationBuilder.AlterColumn<decimal>(
                name: "Lat",
                table: "Markers",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18, 15)");
        }
    }
}
