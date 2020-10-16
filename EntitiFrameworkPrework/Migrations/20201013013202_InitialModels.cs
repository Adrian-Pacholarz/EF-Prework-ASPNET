using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace EntitiFrameworkPrework.Migrations
{
    public partial class InitialModels : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Teams",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(nullable: true),
                    country = table.Column<string>(nullable: true),
                    city = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Teams", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Matches",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    date = table.Column<DateTime>(nullable: false),
                    home_team_id = table.Column<int>(nullable: true),
                    away_team_id = table.Column<int>(nullable: true),
                    goals_home = table.Column<int>(nullable: false),
                    goals_away = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Matches", x => x.id);
                    table.ForeignKey(
                        name: "FK_Matches_Teams_away_team_id",
                        column: x => x.away_team_id,
                        principalTable: "Teams",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Matches_Teams_home_team_id",
                        column: x => x.home_team_id,
                        principalTable: "Teams",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Matches_away_team_id",
                table: "Matches",
                column: "away_team_id");

            migrationBuilder.CreateIndex(
                name: "IX_Matches_home_team_id",
                table: "Matches",
                column: "home_team_id");

            migrationBuilder.Sql("INSERT into Teams VALUES ('The Pipis', 'Spain', 'Madrid')");
            migrationBuilder.Sql("INSERT into Teams VALUES ('FC Codecool', 'Hungary', 'Budapest')");
            migrationBuilder.Sql("INSERT into Teams VALUES ('Black Wolves', 'France', 'Paris')");

            migrationBuilder.Sql("INSERT into Matches VALUES ('20120618 10:34:09 AM', 1, 2, 7, 5)");
            migrationBuilder.Sql("INSERT into Matches VALUES ('20160928 11:47:18 AM', 3, 1, 2, 6)");
            migrationBuilder.Sql("INSERT into Matches VALUES ('20180307 08:10:01 AM', 2, 3, 3, 4)");
            migrationBuilder.Sql("INSERT into Matches VALUES ('20201015 09:20:59 AM', 1, 3, 2, 1)");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Matches");

            migrationBuilder.DropTable(
                name: "Teams");
        }
    }
}
