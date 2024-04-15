using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApplication1.Migrations
{
    /// <inheritdoc />
    public partial class updatedsomemodels : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_solomatches_Agents_Agent_Played",
                table: "solomatches");

            migrationBuilder.DropForeignKey(
                name: "FK_solomatches_maps_Map_Name",
                table: "solomatches");

            migrationBuilder.DropForeignKey(
                name: "FK_solomatches_players_Player_ID",
                table: "solomatches");

            migrationBuilder.DropPrimaryKey(
                name: "PK_solomatches",
                table: "solomatches");

            migrationBuilder.DropPrimaryKey(
                name: "PK_leaderboards",
                table: "leaderboards");

            migrationBuilder.RenameTable(
                name: "solomatches",
                newName: "Solo_matches");

            migrationBuilder.RenameTable(
                name: "leaderboards",
                newName: "player_leaderboard_users");

            migrationBuilder.RenameColumn(
                name: "Player_ID",
                table: "Solo_matches",
                newName: "PlayersPid");

            migrationBuilder.RenameIndex(
                name: "IX_solomatches_Player_ID",
                table: "Solo_matches",
                newName: "IX_Solo_matches_PlayersPid");

            migrationBuilder.RenameIndex(
                name: "IX_solomatches_Map_Name",
                table: "Solo_matches",
                newName: "IX_Solo_matches_Map_Name");

            migrationBuilder.RenameIndex(
                name: "IX_solomatches_Agent_Played",
                table: "Solo_matches",
                newName: "IX_Solo_matches_Agent_Played");

            migrationBuilder.AlterColumn<string>(
                name: "username",
                table: "player_leaderboard_users",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Pname",
                table: "player_leaderboard_users",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Solo_matches",
                table: "Solo_matches",
                column: "Match_ID");

            migrationBuilder.AddUniqueConstraint(
                name: "AK_player_leaderboard_users_username_Pname",
                table: "player_leaderboard_users",
                columns: new[] { "username", "Pname" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_player_leaderboard_users",
                table: "player_leaderboard_users",
                column: "ShadowKey");

            migrationBuilder.AddForeignKey(
                name: "FK_Solo_matches_Agents_Agent_Played",
                table: "Solo_matches",
                column: "Agent_Played",
                principalTable: "Agents",
                principalColumn: "agent_name",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Solo_matches_maps_Map_Name",
                table: "Solo_matches",
                column: "Map_Name",
                principalTable: "maps",
                principalColumn: "Map_Name",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Solo_matches_players_PlayersPid",
                table: "Solo_matches",
                column: "PlayersPid",
                principalTable: "players",
                principalColumn: "Pid",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Solo_matches_Agents_Agent_Played",
                table: "Solo_matches");

            migrationBuilder.DropForeignKey(
                name: "FK_Solo_matches_maps_Map_Name",
                table: "Solo_matches");

            migrationBuilder.DropForeignKey(
                name: "FK_Solo_matches_players_PlayersPid",
                table: "Solo_matches");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Solo_matches",
                table: "Solo_matches");

            migrationBuilder.DropUniqueConstraint(
                name: "AK_player_leaderboard_users_username_Pname",
                table: "player_leaderboard_users");

            migrationBuilder.DropPrimaryKey(
                name: "PK_player_leaderboard_users",
                table: "player_leaderboard_users");

            migrationBuilder.RenameTable(
                name: "Solo_matches",
                newName: "solomatches");

            migrationBuilder.RenameTable(
                name: "player_leaderboard_users",
                newName: "leaderboards");

            migrationBuilder.RenameColumn(
                name: "PlayersPid",
                table: "solomatches",
                newName: "Player_ID");

            migrationBuilder.RenameIndex(
                name: "IX_Solo_matches_PlayersPid",
                table: "solomatches",
                newName: "IX_solomatches_Player_ID");

            migrationBuilder.RenameIndex(
                name: "IX_Solo_matches_Map_Name",
                table: "solomatches",
                newName: "IX_solomatches_Map_Name");

            migrationBuilder.RenameIndex(
                name: "IX_Solo_matches_Agent_Played",
                table: "solomatches",
                newName: "IX_solomatches_Agent_Played");

            migrationBuilder.AlterColumn<string>(
                name: "username",
                table: "leaderboards",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AlterColumn<string>(
                name: "Pname",
                table: "leaderboards",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddPrimaryKey(
                name: "PK_solomatches",
                table: "solomatches",
                column: "Match_ID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_leaderboards",
                table: "leaderboards",
                column: "ShadowKey");

            migrationBuilder.AddForeignKey(
                name: "FK_solomatches_Agents_Agent_Played",
                table: "solomatches",
                column: "Agent_Played",
                principalTable: "Agents",
                principalColumn: "agent_name",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_solomatches_maps_Map_Name",
                table: "solomatches",
                column: "Map_Name",
                principalTable: "maps",
                principalColumn: "Map_Name",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_solomatches_players_Player_ID",
                table: "solomatches",
                column: "Player_ID",
                principalTable: "players",
                principalColumn: "Pid",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
