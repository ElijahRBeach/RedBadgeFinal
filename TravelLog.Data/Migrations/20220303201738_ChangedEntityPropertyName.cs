using Microsoft.EntityFrameworkCore.Migrations;

namespace TravelLog.Data.Migrations
{
    public partial class ChangedEntityPropertyName : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cities_States_StateId",
                table: "Cities");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Countries",
                newName: "CountryId");

            migrationBuilder.RenameColumn(
                name: "StateId",
                table: "Cities",
                newName: "CountryId");

            migrationBuilder.RenameIndex(
                name: "IX_Cities_StateId",
                table: "Cities",
                newName: "IX_Cities_CountryId");

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

            migrationBuilder.AddForeignKey(
                name: "FK_Cities_Countries_CountryId",
                table: "Cities",
                column: "CountryId",
                principalTable: "Countries",
                principalColumn: "CountryId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cities_Countries_CountryId",
                table: "Cities");

            migrationBuilder.DropTable(
                name: "CityEntityStateEntity");

            migrationBuilder.RenameColumn(
                name: "CountryId",
                table: "Countries",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "CountryId",
                table: "Cities",
                newName: "StateId");

            migrationBuilder.RenameIndex(
                name: "IX_Cities_CountryId",
                table: "Cities",
                newName: "IX_Cities_StateId");

            migrationBuilder.AddForeignKey(
                name: "FK_Cities_States_StateId",
                table: "Cities",
                column: "StateId",
                principalTable: "States",
                principalColumn: "StateId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
