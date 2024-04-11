using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApplication1.Migrations
{
    /// <inheritdoc />
    public partial class Addedlocationplayersolomatchesweaponsmapsmodels : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropUniqueConstraint(
                name: "AK_player_leaderboard_users_username_Pname",
                table: "player_leaderboard_users");

            migrationBuilder.DropPrimaryKey(
                name: "PK_player_leaderboard_users",
                table: "player_leaderboard_users");

            migrationBuilder.RenameTable(
                name: "player_leaderboard_users",
                newName: "leaderboards");

            migrationBuilder.AlterColumn<string>(
                name: "suited_weapon",
                table: "Agents",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

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
                name: "PK_leaderboards",
                table: "leaderboards",
                column: "ShadowKey");

            migrationBuilder.CreateTable(
                name: "locations",
                columns: table => new
                {
                    Location_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Country = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_locations", x => x.Location_id);
                });

            migrationBuilder.CreateTable(
                name: "weapons",
                columns: table => new
                {
                    Weapon_Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Weapon_Type = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Capacity = table.Column<int>(type: "int", nullable: true),
                    Fire_Rate = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    Reload_Speed = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    Fire_Mode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Max_Range = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_weapons", x => x.Weapon_Name);
                });

            migrationBuilder.CreateTable(
                name: "players",
                columns: table => new
                {
                    Pid = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Pname = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Location_id = table.Column<int>(type: "int", nullable: false),
                    Fav_agent = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Gender = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Age = table.Column<int>(type: "int", nullable: true),
                    MMR = table.Column<int>(type: "int", nullable: false),
                    Kills = table.Column<int>(type: "int", nullable: false),
                    Deaths = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_players", x => x.Pid);
                    table.ForeignKey(
                        name: "FK_players_Agents_Fav_agent",
                        column: x => x.Fav_agent,
                        principalTable: "Agents",
                        principalColumn: "agent_name",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_players_locations_Location_id",
                        column: x => x.Location_id,
                        principalTable: "locations",
                        principalColumn: "Location_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "maps",
                columns: table => new
                {
                    Map_Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Spike_sites = table.Column<int>(type: "int", nullable: false),
                    Suited_Weapon = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Location_id = table.Column<int>(type: "int", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_maps", x => x.Map_Name);
                    table.ForeignKey(
                        name: "FK_maps_locations_Location_id",
                        column: x => x.Location_id,
                        principalTable: "locations",
                        principalColumn: "Location_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_maps_weapons_Suited_Weapon",
                        column: x => x.Suited_Weapon,
                        principalTable: "weapons",
                        principalColumn: "Weapon_Name",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "solomatches",
                columns: table => new
                {
                    Match_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Kills = table.Column<int>(type: "int", nullable: true),
                    Deaths = table.Column<int>(type: "int", nullable: true),
                    Result = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Agent_Played = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Map_Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Player_ID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_solomatches", x => x.Match_ID);
                    table.ForeignKey(
                        name: "FK_solomatches_Agents_Agent_Played",
                        column: x => x.Agent_Played,
                        principalTable: "Agents",
                        principalColumn: "agent_name",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_solomatches_maps_Map_Name",
                        column: x => x.Map_Name,
                        principalTable: "maps",
                        principalColumn: "Map_Name",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_solomatches_players_Player_ID",
                        column: x => x.Player_ID,
                        principalTable: "players",
                        principalColumn: "Pid",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Agents_suited_weapon",
                table: "Agents",
                column: "suited_weapon");

            migrationBuilder.CreateIndex(
                name: "IX_maps_Location_id",
                table: "maps",
                column: "Location_id");

            migrationBuilder.CreateIndex(
                name: "IX_maps_Suited_Weapon",
                table: "maps",
                column: "Suited_Weapon");

            migrationBuilder.CreateIndex(
                name: "IX_players_Fav_agent",
                table: "players",
                column: "Fav_agent");

            migrationBuilder.CreateIndex(
                name: "IX_players_Location_id",
                table: "players",
                column: "Location_id");

            migrationBuilder.CreateIndex(
                name: "IX_solomatches_Agent_Played",
                table: "solomatches",
                column: "Agent_Played");

            migrationBuilder.CreateIndex(
                name: "IX_solomatches_Map_Name",
                table: "solomatches",
                column: "Map_Name");

            migrationBuilder.CreateIndex(
                name: "IX_solomatches_Player_ID",
                table: "solomatches",
                column: "Player_ID");

            migrationBuilder.AddForeignKey(
                name: "FK_Agents_weapons_suited_weapon",
                table: "Agents",
                column: "suited_weapon",
                principalTable: "weapons",
                principalColumn: "Weapon_Name");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Agents_weapons_suited_weapon",
                table: "Agents");

            migrationBuilder.DropTable(
                name: "solomatches");

            migrationBuilder.DropTable(
                name: "maps");

            migrationBuilder.DropTable(
                name: "players");

            migrationBuilder.DropTable(
                name: "weapons");

            migrationBuilder.DropTable(
                name: "locations");

            migrationBuilder.DropIndex(
                name: "IX_Agents_suited_weapon",
                table: "Agents");

            migrationBuilder.DropPrimaryKey(
                name: "PK_leaderboards",
                table: "leaderboards");

            migrationBuilder.RenameTable(
                name: "leaderboards",
                newName: "player_leaderboard_users");

            migrationBuilder.AlterColumn<string>(
                name: "suited_weapon",
                table: "Agents",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

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

            migrationBuilder.AddUniqueConstraint(
                name: "AK_player_leaderboard_users_username_Pname",
                table: "player_leaderboard_users",
                columns: new[] { "username", "Pname" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_player_leaderboard_users",
                table: "player_leaderboard_users",
                column: "ShadowKey");
        }
    }
}
