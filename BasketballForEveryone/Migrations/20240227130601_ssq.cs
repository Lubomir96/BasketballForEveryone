using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BasketballForEveryone.Migrations
{
    /// <inheritdoc />
    public partial class ssq : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "BPlayers_BestPlayers",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Id",
                table: "BPlayers_BestPlayers");
        }
    }
}
