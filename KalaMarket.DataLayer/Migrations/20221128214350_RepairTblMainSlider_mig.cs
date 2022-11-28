using Microsoft.EntityFrameworkCore.Migrations;

namespace KalaMarket.DataLayer.Migrations
{
    public partial class RepairTblMainSlider_mig : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "SliderImage",
                table: "MainSliders",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SliderImage",
                table: "MainSliders");
        }
    }
}
