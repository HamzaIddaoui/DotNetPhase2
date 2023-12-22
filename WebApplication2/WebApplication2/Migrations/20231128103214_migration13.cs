using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApplication2.Migrations
{
    /// <inheritdoc />
    public partial class migration13 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CartItem_Cart_CartId",
                table: "CartItem");

            migrationBuilder.DropForeignKey(
                name: "FK_Item_Product_ProductId",
                table: "Item");

            migrationBuilder.DropIndex(
                name: "IX_Item_ProductId",
                table: "Item");

            migrationBuilder.DropIndex(
                name: "IX_CartItem_CartId",
                table: "CartItem");

            migrationBuilder.DropColumn(
                name: "ProductId",
                table: "Item");

            migrationBuilder.DropColumn(
                name: "CartId",
                table: "CartItem");

            migrationBuilder.CreateIndex(
                name: "IX_Item_Product_Id",
                table: "Item",
                column: "Product_Id");

            migrationBuilder.CreateIndex(
                name: "IX_CartItem_Cart_Id",
                table: "CartItem",
                column: "Cart_Id");

            migrationBuilder.AddForeignKey(
                name: "FK_CartItem_Cart_Cart_Id",
                table: "CartItem",
                column: "Cart_Id",
                principalTable: "Cart",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Item_Product_Product_Id",
                table: "Item",
                column: "Product_Id",
                principalTable: "Product",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CartItem_Cart_Cart_Id",
                table: "CartItem");

            migrationBuilder.DropForeignKey(
                name: "FK_Item_Product_Product_Id",
                table: "Item");

            migrationBuilder.DropIndex(
                name: "IX_Item_Product_Id",
                table: "Item");

            migrationBuilder.DropIndex(
                name: "IX_CartItem_Cart_Id",
                table: "CartItem");

            migrationBuilder.AddColumn<int>(
                name: "ProductId",
                table: "Item",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CartId",
                table: "CartItem",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Item_ProductId",
                table: "Item",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_CartItem_CartId",
                table: "CartItem",
                column: "CartId");

            migrationBuilder.AddForeignKey(
                name: "FK_CartItem_Cart_CartId",
                table: "CartItem",
                column: "CartId",
                principalTable: "Cart",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Item_Product_ProductId",
                table: "Item",
                column: "ProductId",
                principalTable: "Product",
                principalColumn: "Id");
        }
    }
}
