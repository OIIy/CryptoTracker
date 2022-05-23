using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CryptoTracker.Api.Migrations
{
    public partial class addJwtTokenColumnToUserModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Jwt",
                table: "Users",
                type: "nvarchar(MAX)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Jwt",
                table: "Users");
        }
    }
}
