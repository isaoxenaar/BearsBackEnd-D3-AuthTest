using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SignalRWebpack.Migrations
{
    public partial class DeleteObserver : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Bears_Observers_ObserverId",
                table: "Bears");

            migrationBuilder.DropForeignKey(
                name: "FK_Bears_Users_UserId",
                table: "Bears");

            migrationBuilder.DropTable(
                name: "Observers");

            migrationBuilder.DropIndex(
                name: "IX_Bears_UserId",
                table: "Bears");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Bears");

            migrationBuilder.CreateIndex(
                name: "IX_Users_Name",
                table: "Users",
                column: "Name",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Bears_Users_ObserverId",
                table: "Bears",
                column: "ObserverId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Bears_Users_ObserverId",
                table: "Bears");

            migrationBuilder.DropIndex(
                name: "IX_Users_Name",
                table: "Users");

            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "Bears",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Observers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Color = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Observers", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Bears_UserId",
                table: "Bears",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Observers_Name",
                table: "Observers",
                column: "Name",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Bears_Observers_ObserverId",
                table: "Bears",
                column: "ObserverId",
                principalTable: "Observers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Bears_Users_UserId",
                table: "Bears",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id");
        }
    }
}
