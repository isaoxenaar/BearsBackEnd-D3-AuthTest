using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SignalRWebpack.Migrations
{
    public partial class Updateuser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Users",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Color",
                table: "Users",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "Observers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Password",
                table: "Observers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "Bears",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Bears_UserId",
                table: "Bears",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Bears_Users_UserId",
                table: "Bears",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Bears_Users_UserId",
                table: "Bears");

            migrationBuilder.DropIndex(
                name: "IX_Bears_UserId",
                table: "Bears");

            migrationBuilder.DropColumn(
                name: "Color",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "Email",
                table: "Observers");

            migrationBuilder.DropColumn(
                name: "Password",
                table: "Observers");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Bears");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Users",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(20)",
                oldMaxLength: 20);
        }
    }
}
