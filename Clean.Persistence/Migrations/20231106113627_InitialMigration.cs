using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Handshake.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class InitialMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Students",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    CheckInTime = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Students", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Students",
                columns: new[] { "Id", "CheckInTime", "FirstName", "LastName" },
                values: new object[,]
                {
                    { 1, new DateTime(2023, 10, 29, 8, 0, 0, 0, DateTimeKind.Unspecified), "John", "Doe" },
                    { 2, new DateTime(2023, 10, 31, 8, 0, 0, 0, DateTimeKind.Unspecified), "Jane", "Doe" },
                    { 3, new DateTime(2023, 10, 31, 8, 0, 0, 0, DateTimeKind.Unspecified), "John", "Smith" },
                    { 4, new DateTime(2023, 11, 1, 8, 0, 0, 0, DateTimeKind.Unspecified), "Jane", "Smith" },
                    { 5, new DateTime(2023, 11, 1, 8, 0, 0, 0, DateTimeKind.Unspecified), "John", "Jones" },
                    { 6, new DateTime(2023, 11, 1, 8, 0, 0, 0, DateTimeKind.Unspecified), "Jane", "Jones" },
                    { 7, new DateTime(2023, 11, 1, 8, 0, 0, 0, DateTimeKind.Unspecified), "John", "Williams" },
                    { 8, new DateTime(2023, 11, 1, 8, 0, 0, 0, DateTimeKind.Unspecified), "Jane", "Williams" },
                    { 9, new DateTime(2023, 11, 1, 8, 0, 0, 0, DateTimeKind.Unspecified), "John", "Brown" },
                    { 10, new DateTime(2023, 11, 1, 8, 0, 0, 0, DateTimeKind.Unspecified), "Jane", "Brown" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Students");
        }
    }
}
