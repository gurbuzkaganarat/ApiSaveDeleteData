using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ApiForm.Migrations
{
    /// <inheritdoc />
    public partial class @new : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Meta",
                columns: table => new
                {
                    MetaId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    total_pages = table.Column<int>(type: "int", nullable: false),
                    current_page = table.Column<int>(type: "int", nullable: false),
                    next_page = table.Column<int>(type: "int", nullable: false),
                    per_page = table.Column<int>(type: "int", nullable: false),
                    total_count = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Meta", x => x.MetaId);
                });

            migrationBuilder.CreateTable(
                name: "Team",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    abbreviation = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    city = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    conference = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    division = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    full_name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Team", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Root",
                columns: table => new
                {
                    RootId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MetaId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Root", x => x.RootId);
                    table.ForeignKey(
                        name: "FK_Root_Meta_MetaId",
                        column: x => x.MetaId,
                        principalTable: "Meta",
                        principalColumn: "MetaId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Player",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    first_name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    height_feet = table.Column<int>(type: "int", nullable: true),
                    height_inches = table.Column<int>(type: "int", nullable: true),
                    last_name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    position = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    teamid = table.Column<int>(type: "int", nullable: true),
                    weight_pounds = table.Column<int>(type: "int", nullable: true),
                    RootId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Player", x => x.id);
                    table.ForeignKey(
                        name: "FK_Player_Root_RootId",
                        column: x => x.RootId,
                        principalTable: "Root",
                        principalColumn: "RootId");
                    table.ForeignKey(
                        name: "FK_Player_Team_teamid",
                        column: x => x.teamid,
                        principalTable: "Team",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Player_RootId",
                table: "Player",
                column: "RootId");

            migrationBuilder.CreateIndex(
                name: "IX_Player_teamid",
                table: "Player",
                column: "teamid");

            migrationBuilder.CreateIndex(
                name: "IX_Root_MetaId",
                table: "Root",
                column: "MetaId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Player");

            migrationBuilder.DropTable(
                name: "Root");

            migrationBuilder.DropTable(
                name: "Team");

            migrationBuilder.DropTable(
                name: "Meta");
        }
    }
}
