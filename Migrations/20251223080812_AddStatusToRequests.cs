using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ELDNET_Lloyd.Migrations
{
    /// <inheritdoc />
    public partial class AddStatusToRequests : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Status",
                table: "Lockers",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Status",
                table: "GatePasses",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Status",
                table: "Activities",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Status",
                table: "Lockers");

            migrationBuilder.DropColumn(
                name: "Status",
                table: "GatePasses");

            migrationBuilder.DropColumn(
                name: "Status",
                table: "Activities");
        }
    }
}
