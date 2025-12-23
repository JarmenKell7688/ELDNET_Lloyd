using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ELDNET_Lloyd.Migrations
{
    /// <inheritdoc />
    public partial class AddCourseToStudent : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Course",
                table: "AspNetUsers",
                type: "nvarchar(60)",
                maxLength: 60,
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Course",
                table: "AspNetUsers");
        }
    }
}
