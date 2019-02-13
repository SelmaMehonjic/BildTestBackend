using Microsoft.EntityFrameworkCore.Migrations;

namespace bildExamNew.Migrations
{
    public partial class ChangePriceToDecimal : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<decimal>(
                name: "Price",
                table: "Devices",
                nullable: false,
                oldClrType: typeof(int));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "Price",
                table: "Devices",
                nullable: false,
                oldClrType: typeof(decimal));
        }
    }
}
