using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApplication1.Migrations
{
    /// <inheritdoc />
    public partial class CreatedLeaderboardviewModel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "player_leaderboard_users",
                columns: table => new
                {
                    ShadowKey = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    username = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Pname = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    fav_agent = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    KD_Ratio = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    country = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MMR = table.Column<int>(type: "int", nullable: false),
                    kills = table.Column<int>(type: "int", nullable: false),
                    deaths = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_player_leaderboard_users", x => x.ShadowKey);
                    table.UniqueConstraint("AK_player_leaderboard_users_username_Pname", x => new { x.username, x.Pname });
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "player_leaderboard_users");
        }
    }
}
