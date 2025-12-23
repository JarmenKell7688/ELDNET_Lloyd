using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ELDNET_Lloyd.Migrations
{
    /// <inheritdoc />
    public partial class ModelCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Activities",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OrganizationName = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: false),
                    ActivityTitle = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Venue = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: false),
                    DateNeeded = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TimeFrom = table.Column<TimeSpan>(type: "time", nullable: false),
                    TimeTo = table.Column<TimeSpan>(type: "time", nullable: false),
                    Participants = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Speaker = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: false),
                    Purpose = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    EquipmentNeeded = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    NatureOfActivity = table.Column<string>(type: "nvarchar(70)", maxLength: 70, nullable: false),
                    SourceOfFunds = table.Column<string>(type: "nvarchar(70)", maxLength: 70, nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    StudentId = table.Column<int>(type: "int", nullable: false),
                    FileData = table.Column<byte[]>(type: "varbinary(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Activities", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Activities_AspNetUsers_StudentId",
                        column: x => x.StudentId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "GatePasses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SchoolYear = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Address = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Type = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Department = table.Column<string>(type: "nvarchar(70)", maxLength: 70, nullable: false),
                    CourseYear = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    VehiclePlateNo = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false),
                    RegistrationExpiry = table.Column<DateTime>(type: "datetime2", nullable: false),
                    VehicleType = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false),
                    Maker = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    Color = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: false),
                    DocumentFile = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    StudentId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GatePasses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_GatePasses_AspNetUsers_StudentId",
                        column: x => x.StudentId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Lockers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    IdNumber = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    LockerNumber = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Semester = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    ContactNumber = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    DocumentFile = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    StudentId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Lockers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Lockers_AspNetUsers_StudentId",
                        column: x => x.StudentId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Activities_StudentId",
                table: "Activities",
                column: "StudentId");

            migrationBuilder.CreateIndex(
                name: "IX_GatePasses_StudentId",
                table: "GatePasses",
                column: "StudentId");

            migrationBuilder.CreateIndex(
                name: "IX_Lockers_StudentId",
                table: "Lockers",
                column: "StudentId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Activities");

            migrationBuilder.DropTable(
                name: "GatePasses");

            migrationBuilder.DropTable(
                name: "Lockers");
        }
    }
}
