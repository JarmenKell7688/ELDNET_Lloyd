using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ELDNET_Lloyd.Migrations
{
    /// <inheritdoc />
    public partial class UpdateDocumentPathInDatabase : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DocumentFile",
                table: "Lockers");

            migrationBuilder.DropColumn(
                name: "DocumentFile",
                table: "GatePasses");

            migrationBuilder.AddColumn<string>(
                name: "DocumentFilesJson",
                table: "Lockers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DocumentFilesJson",
                table: "GatePasses",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DocumentFilesJson",
                table: "Lockers");

            migrationBuilder.DropColumn(
                name: "DocumentFilesJson",
                table: "GatePasses");

            migrationBuilder.AddColumn<byte[]>(
                name: "DocumentFile",
                table: "Lockers",
                type: "varbinary(max)",
                nullable: true);

            migrationBuilder.AddColumn<byte[]>(
                name: "DocumentFile",
                table: "GatePasses",
                type: "varbinary(max)",
                nullable: true);
        }
    }
}
