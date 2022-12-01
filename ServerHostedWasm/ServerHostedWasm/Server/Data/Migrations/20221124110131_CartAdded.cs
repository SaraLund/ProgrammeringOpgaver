using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ServerHostedWasm.Server.Data.Migrations
{
    public partial class CartAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ShoppingCartID",
                table: "Surfboard",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "MyCartID",
                table: "AspNetUsers",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "shoppingCarts",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_shoppingCarts", x => x.ID);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Surfboard_ShoppingCartID",
                table: "Surfboard",
                column: "ShoppingCartID");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_MyCartID",
                table: "AspNetUsers",
                column: "MyCartID");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_shoppingCarts_MyCartID",
                table: "AspNetUsers",
                column: "MyCartID",
                principalTable: "shoppingCarts",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Surfboard_shoppingCarts_ShoppingCartID",
                table: "Surfboard",
                column: "ShoppingCartID",
                principalTable: "shoppingCarts",
                principalColumn: "ID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_shoppingCarts_MyCartID",
                table: "AspNetUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_Surfboard_shoppingCarts_ShoppingCartID",
                table: "Surfboard");

            migrationBuilder.DropTable(
                name: "shoppingCarts");

            migrationBuilder.DropIndex(
                name: "IX_Surfboard_ShoppingCartID",
                table: "Surfboard");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_MyCartID",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "ShoppingCartID",
                table: "Surfboard");

            migrationBuilder.DropColumn(
                name: "MyCartID",
                table: "AspNetUsers");
        }
    }
}
