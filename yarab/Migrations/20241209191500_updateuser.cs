using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace yarab.Migrations
{
    /// <inheritdoc />
    public partial class updateuser : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Area",
                table: "Users",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "password",
                table: "Users",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Area",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "password",
                table: "Users");
        }
    }
}
