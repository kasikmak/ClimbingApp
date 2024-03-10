using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ClimbingApp.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class Relations : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Route",
                table: "Route");

            migrationBuilder.RenameTable(
                name: "Route",
                newName: "Routes");

            migrationBuilder.AddColumn<int>(
                name: "RouteId",
                table: "Ascents",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "EquiperId",
                table: "Routes",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Routes",
                table: "Routes",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "RouteUser",
                columns: table => new
                {
                    ClimbersId = table.Column<int>(type: "int", nullable: false),
                    RoutesId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RouteUser", x => new { x.ClimbersId, x.RoutesId });
                    table.ForeignKey(
                        name: "FK_RouteUser_Routes_RoutesId",
                        column: x => x.RoutesId,
                        principalTable: "Routes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RouteUser_Users_ClimbersId",
                        column: x => x.ClimbersId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Ascents_RouteId",
                table: "Ascents",
                column: "RouteId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_RouteUser_RoutesId",
                table: "RouteUser",
                column: "RoutesId");

            migrationBuilder.AddForeignKey(
                name: "FK_Ascents_Routes_RouteId",
                table: "Ascents",
                column: "RouteId",
                principalTable: "Routes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Ascents_Routes_RouteId",
                table: "Ascents");

            migrationBuilder.DropTable(
                name: "RouteUser");

            migrationBuilder.DropIndex(
                name: "IX_Ascents_RouteId",
                table: "Ascents");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Routes",
                table: "Routes");

            migrationBuilder.DropColumn(
                name: "RouteId",
                table: "Ascents");

            migrationBuilder.DropColumn(
                name: "EquiperId",
                table: "Routes");

            migrationBuilder.RenameTable(
                name: "Routes",
                newName: "Route");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Route",
                table: "Route",
                column: "Id");
        }
    }
}
