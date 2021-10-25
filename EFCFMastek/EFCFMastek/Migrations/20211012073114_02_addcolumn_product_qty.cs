using Microsoft.EntityFrameworkCore.Migrations;

namespace EFCFMastek.Migrations
{
    public partial class _02_addcolumn_product_qty : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "Quantity",
                table: "Product",
                type: "numeric(4)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Quantity",
                table: "Product");
        }
    }
}
