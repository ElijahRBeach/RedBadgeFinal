using Microsoft.EntityFrameworkCore.Migrations;

namespace TravelLog.Data.Migrations
{
    public partial class ChangedStateCityRShip : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CityEntityStateEntity");

            migrationBuilder.AddColumn<int>(
                name: "StateId",
                table: "Cities",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Cities_StateId",
                table: "Cities",
                column: "StateId");

            migrationBuilder.AddForeignKey(
                name: "FK_Cities_States_StateId",
                table: "Cities",
                column: "StateId",
                principalTable: "States",
                principalColumn: "StateId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cities_States_StateId",
                table: "Cities");

            migrationBuilder.DropIndex(
                name: "IX_Cities_StateId",
                table: "Cities");

            migrationBuilder.DropColumn(
                name: "StateId",
                table: "Cities");

            migrationBuilder.CreateTable(
                name: "CityEntityStateEntity",
                columns: table => new
                {
                    CitiesCityId = table.Column<int>(type: "int", nullable: false),
                    StatesStateId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CityEntityStateEntity", x => new { x.CitiesCityId, x.StatesStateId });
                    table.ForeignKey(
                        name: "FK_CityEntityStateEntity_Cities_CitiesCityId",
                        column: x => x.CitiesCityId,
                        principalTable: "Cities",
                        principalColumn: "CityId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CityEntityStateEntity_States_StatesStateId",
                        column: x => x.StatesStateId,
                        principalTable: "States",
                        principalColumn: "StateId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CityEntityStateEntity_StatesStateId",
                table: "CityEntityStateEntity",
                column: "StatesStateId");
        }
    }
}
