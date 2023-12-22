using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApplication2.Migrations
{
    /// <inheritdoc />
    public partial class migration22 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CartItem_Item_itemId",
                table: "CartItem");

            migrationBuilder.DropIndex(
                name: "IX_CartItem_itemId",
                table: "CartItem");

            migrationBuilder.DropColumn(
                name: "itemId",
                table: "CartItem");

            migrationBuilder.CreateIndex(
                name: "IX_CartItem_Item_Id",
                table: "CartItem",
                column: "Item_Id");

            migrationBuilder.AddForeignKey(
                name: "FK_CartItem_Item_Item_Id",
                table: "CartItem",
                column: "Item_Id",
                principalTable: "Item",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CartItem_Item_Item_Id",
                table: "CartItem");

            migrationBuilder.DropIndex(
                name: "IX_CartItem_Item_Id",
                table: "CartItem");

            migrationBuilder.AddColumn<int>(
                name: "itemId",
                table: "CartItem",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_CartItem_itemId",
                table: "CartItem",
                column: "itemId");

            migrationBuilder.AddForeignKey(
                name: "FK_CartItem_Item_itemId",
                table: "CartItem",
                column: "itemId",
                principalTable: "Item",
                principalColumn: "Id");
        }
    }
}
