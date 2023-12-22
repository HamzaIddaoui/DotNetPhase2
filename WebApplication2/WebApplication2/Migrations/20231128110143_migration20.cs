using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApplication2.Migrations
{
    /// <inheritdoc />
    public partial class migration20 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CartItem_Item_Item_Id",
                table: "CartItem");

            migrationBuilder.DropTable(
                name: "Item");

            migrationBuilder.RenameColumn(
                name: "Item_Id",
                table: "CartItem",
                newName: "Product_Id");

            migrationBuilder.RenameIndex(
                name: "IX_CartItem_Item_Id",
                table: "CartItem",
                newName: "IX_CartItem_Product_Id");

            migrationBuilder.AddForeignKey(
                name: "FK_CartItem_Product_Product_Id",
                table: "CartItem",
                column: "Product_Id",
                principalTable: "Product",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CartItem_Product_Product_Id",
                table: "CartItem");

            migrationBuilder.RenameColumn(
                name: "Product_Id",
                table: "CartItem",
                newName: "Item_Id");

            migrationBuilder.RenameIndex(
                name: "IX_CartItem_Product_Id",
                table: "CartItem",
                newName: "IX_CartItem_Item_Id");

            migrationBuilder.CreateTable(
                name: "Item",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Product_Id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Item", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Item_Product_Product_Id",
                        column: x => x.Product_Id,
                        principalTable: "Product",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Item_Product_Id",
                table: "Item",
                column: "Product_Id");

            migrationBuilder.AddForeignKey(
                name: "FK_CartItem_Item_Item_Id",
                table: "CartItem",
                column: "Item_Id",
                principalTable: "Item",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
