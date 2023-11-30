using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Clean.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class InitialMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CheckIn",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Major = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CheckInTime = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CheckIn", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Students",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Students", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "CheckIn",
                columns: new[] { "Id", "CheckInTime", "Email", "Major" },
                values: new object[,]
                {
                    { 1, new DateTime(2023, 1, 1, 8, 0, 0, 0, DateTimeKind.Unspecified), "john@doe@email.com", "Computer Science" },
                    { 2, new DateTime(2023, 1, 2, 9, 0, 0, 0, DateTimeKind.Unspecified), "john@doe@email.com", "Computer Science" },
                    { 3, new DateTime(2023, 1, 1, 8, 0, 0, 0, DateTimeKind.Unspecified), "jane@doe@email.com", "Computer Science" },
                    { 4, new DateTime(2023, 1, 1, 8, 0, 0, 0, DateTimeKind.Unspecified), "john.smith@email.com", "Accounting" },
                    { 5, new DateTime(2023, 1, 1, 8, 0, 0, 0, DateTimeKind.Unspecified), "jane.smith@email.com", "Finance" },
                    { 6, new DateTime(2023, 1, 1, 8, 0, 0, 0, DateTimeKind.Unspecified), "john.jones@email.com", "General Management" },
                    { 7, new DateTime(2023, 1, 1, 8, 0, 0, 0, DateTimeKind.Unspecified), "jane@jones@email.com", "Business Analytics" }
                });

            migrationBuilder.InsertData(
                table: "Students",
                columns: new[] { "Id", "Email", "FirstName", "LastName" },
                values: new object[,]
                {
                    { 1, "john@doe@email.com", "John", "Doe" },
                    { 2, "jane@doe@email.com", "Jane", "Doe" },
                    { 3, "john.smith@email.com", "John", "Smith" },
                    { 4, "jane.smith@email.com", "Jane", "Smith" },
                    { 5, "john.jones@email.com", "John", "Jones" },
                    { 6, "jane@jones@email.com", "Jane", "Jones" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CheckIn");

            migrationBuilder.DropTable(
                name: "Students");
        }
    }
}
