using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CryptoTracker.Api.Migrations
{
    public partial class removeJwtTokenColumnToUserModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Jwt",
                table: "Users");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Jwt",
                table: "Users",
                type: "nvarchar(MAX)",
                nullable: true);
        }
    }
}
