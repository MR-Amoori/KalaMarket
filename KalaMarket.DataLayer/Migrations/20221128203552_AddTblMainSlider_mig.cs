using Microsoft.EntityFrameworkCore.Migrations;

namespace KalaMarket.DataLayer.Migrations
{
    public partial class AddTblMainSlider_mig : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "MainSliders",
                columns: table => new
                {
                    SliderId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SliderLink = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    SliderAlt = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    SliderTitle = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    SliderSort = table.Column<int>(type: "int", maxLength: 100, nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MainSliders", x => x.SliderId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MainSliders");
        }
    }
}
