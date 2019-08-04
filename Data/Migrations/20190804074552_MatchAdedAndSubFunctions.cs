using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace PROHockeyPlanner.Data.Migrations
{
    public partial class MatchAdedAndSubFunctions : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AgeCategory",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    AgeCategoryName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AgeCategory", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Arena",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ArenaName = table.Column<string>(nullable: true),
                    StreetAddress = table.Column<string>(nullable: true),
                    ZipCode = table.Column<string>(nullable: true),
                    City = table.Column<string>(nullable: true),
                    CountryId = table.Column<int>(nullable: true),
                    PhoneNumber1 = table.Column<string>(nullable: true),
                    PhoneNumber2 = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Arena", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Arena_Country_CountryId",
                        column: x => x.CountryId,
                        principalTable: "Country",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "MatchCategory",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    MatchCategoryName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MatchCategory", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MatchStatus",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    MatchStatusName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MatchStatus", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Team",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    AgeCategoryId = table.Column<int>(nullable: true),
                    ClubId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Team", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Team_AgeCategory_AgeCategoryId",
                        column: x => x.AgeCategoryId,
                        principalTable: "AgeCategory",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Team_Club_ClubId",
                        column: x => x.ClubId,
                        principalTable: "Club",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Match",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    MatchCategoryId = table.Column<int>(nullable: true),
                    AgeCategoryId = table.Column<int>(nullable: true),
                    GameNumber = table.Column<string>(nullable: true),
                    GameDateTime = table.Column<DateTime>(nullable: true),
                    ArenaId = table.Column<int>(nullable: true),
                    TeamId = table.Column<int>(nullable: true),
                    TeamId1 = table.Column<int>(nullable: true),
                    HomeTeamScore = table.Column<int>(nullable: true),
                    AwayTeamScore = table.Column<int>(nullable: true),
                    RefereeId = table.Column<int>(nullable: true),
                    RefereeId1 = table.Column<int>(nullable: true),
                    RefereeId2 = table.Column<int>(nullable: true),
                    RefereeId3 = table.Column<int>(nullable: true),
                    MatchStatusId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Match", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Match_AgeCategory_AgeCategoryId",
                        column: x => x.AgeCategoryId,
                        principalTable: "AgeCategory",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Match_Arena_ArenaId",
                        column: x => x.ArenaId,
                        principalTable: "Arena",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Match_MatchCategory_MatchCategoryId",
                        column: x => x.MatchCategoryId,
                        principalTable: "MatchCategory",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Match_MatchStatus_MatchStatusId",
                        column: x => x.MatchStatusId,
                        principalTable: "MatchStatus",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Match_Referee_RefereeId",
                        column: x => x.RefereeId,
                        principalTable: "Referee",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Match_Referee_RefereeId1",
                        column: x => x.RefereeId1,
                        principalTable: "Referee",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Match_Referee_RefereeId2",
                        column: x => x.RefereeId2,
                        principalTable: "Referee",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Match_Referee_RefereeId3",
                        column: x => x.RefereeId3,
                        principalTable: "Referee",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Match_Team_TeamId",
                        column: x => x.TeamId,
                        principalTable: "Team",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Match_Team_TeamId1",
                        column: x => x.TeamId1,
                        principalTable: "Team",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Arena_CountryId",
                table: "Arena",
                column: "CountryId");

            migrationBuilder.CreateIndex(
                name: "IX_Match_AgeCategoryId",
                table: "Match",
                column: "AgeCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Match_ArenaId",
                table: "Match",
                column: "ArenaId");

            migrationBuilder.CreateIndex(
                name: "IX_Match_MatchCategoryId",
                table: "Match",
                column: "MatchCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Match_MatchStatusId",
                table: "Match",
                column: "MatchStatusId");

            migrationBuilder.CreateIndex(
                name: "IX_Match_RefereeId",
                table: "Match",
                column: "RefereeId");

            migrationBuilder.CreateIndex(
                name: "IX_Match_RefereeId1",
                table: "Match",
                column: "RefereeId1");

            migrationBuilder.CreateIndex(
                name: "IX_Match_RefereeId2",
                table: "Match",
                column: "RefereeId2");

            migrationBuilder.CreateIndex(
                name: "IX_Match_RefereeId3",
                table: "Match",
                column: "RefereeId3");

            migrationBuilder.CreateIndex(
                name: "IX_Match_TeamId",
                table: "Match",
                column: "TeamId");

            migrationBuilder.CreateIndex(
                name: "IX_Match_TeamId1",
                table: "Match",
                column: "TeamId1");

            migrationBuilder.CreateIndex(
                name: "IX_Team_AgeCategoryId",
                table: "Team",
                column: "AgeCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Team_ClubId",
                table: "Team",
                column: "ClubId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Match");

            migrationBuilder.DropTable(
                name: "Arena");

            migrationBuilder.DropTable(
                name: "MatchCategory");

            migrationBuilder.DropTable(
                name: "MatchStatus");

            migrationBuilder.DropTable(
                name: "Team");

            migrationBuilder.DropTable(
                name: "AgeCategory");
        }
    }
}
