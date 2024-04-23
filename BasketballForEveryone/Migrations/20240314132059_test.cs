using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BasketballForEveryone.Migrations
{
    /// <inheritdoc />
    public partial class test : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ShoppingCartItems_BestPlayers_bestPlayerId",
                table: "ShoppingCartItems");

            migrationBuilder.RenameColumn(
                name: "bestPlayerId",
                table: "ShoppingCartItems",
                newName: "BestPlayerId");

            migrationBuilder.RenameIndex(
                name: "IX_ShoppingCartItems_bestPlayerId",
                table: "ShoppingCartItems",
                newName: "IX_ShoppingCartItems_BestPlayerId");

            migrationBuilder.AddForeignKey(
                name: "FK_ShoppingCartItems_BestPlayers_BestPlayerId",
                table: "ShoppingCartItems",
                column: "BestPlayerId",
                principalTable: "BestPlayers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ShoppingCartItems_BestPlayers_BestPlayerId",
                table: "ShoppingCartItems");

            migrationBuilder.RenameColumn(
                name: "BestPlayerId",
                table: "ShoppingCartItems",
                newName: "bestPlayerId");

            migrationBuilder.RenameIndex(
                name: "IX_ShoppingCartItems_BestPlayerId",
                table: "ShoppingCartItems",
                newName: "IX_ShoppingCartItems_bestPlayerId");

            migrationBuilder.AddForeignKey(
                name: "FK_ShoppingCartItems_BestPlayers_bestPlayerId",
                table: "ShoppingCartItems",
                column: "bestPlayerId",
                principalTable: "BestPlayers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
