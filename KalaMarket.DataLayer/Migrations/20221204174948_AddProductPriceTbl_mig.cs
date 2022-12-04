using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace KalaMarket.DataLayer.Migrations
{
    public partial class AddProductPriceTbl_mig : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ProductPrices",
                columns: table => new
                {
                    ProductPriceId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MainPrice = table.Column<int>(type: "int", nullable: false),
                    SpacialPrice = table.Column<int>(type: "int", nullable: false),
                    Count = table.Column<int>(type: "int", nullable: false),
                    MaxOrderCount = table.Column<int>(type: "int", nullable: false),
                    productColorId = table.Column<int>(type: "int", nullable: false),
                    ProductGarrantyId = table.Column<int>(type: "int", nullable: false),
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndDateDiscount = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductPrices", x => x.ProductPriceId);
                    table.ForeignKey(
                        name: "FK_ProductPrices_ProductColors_productColorId",
                        column: x => x.productColorId,
                        principalTable: "ProductColors",
                        principalColumn: "ProductColorId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ProductPrices_ProductGarranties_ProductGarrantyId",
                        column: x => x.ProductGarrantyId,
                        principalTable: "ProductGarranties",
                        principalColumn: "ProductGarrantyId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ProductPrices_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "ProductId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ProductPrices_productColorId",
                table: "ProductPrices",
                column: "productColorId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductPrices_ProductGarrantyId",
                table: "ProductPrices",
                column: "ProductGarrantyId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductPrices_ProductId",
                table: "ProductPrices",
                column: "ProductId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProductPrices");
        }
    }
}
