using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Portfolio_Backend.Migrations
{
    /// <inheritdoc />
    public partial class Update1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_login",
                table: "login");

            migrationBuilder.RenameTable(
                name: "login",
                newName: "Users");

            migrationBuilder.RenameColumn(
                name: "Salt",
                table: "Users",
                newName: "salt");

            migrationBuilder.RenameColumn(
                name: "Password",
                table: "Users",
                newName: "password");

            migrationBuilder.RenameColumn(
                name: "Email",
                table: "Users",
                newName: "email");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Users",
                table: "Users",
                column: "email");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Users",
                table: "Users");

            migrationBuilder.RenameTable(
                name: "Users",
                newName: "login");

            migrationBuilder.RenameColumn(
                name: "salt",
                table: "login",
                newName: "Salt");

            migrationBuilder.RenameColumn(
                name: "password",
                table: "login",
                newName: "Password");

            migrationBuilder.RenameColumn(
                name: "email",
                table: "login",
                newName: "Email");

            migrationBuilder.AddPrimaryKey(
                name: "PK_login",
                table: "login",
                column: "Email");
        }
    }
}
