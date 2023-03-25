using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace webApi.Migrations
{
    /// <inheritdoc />
    public partial class init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "owners",
                columns: table => new
                {
                    OwnerId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: false),
                    DateOfBirth = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_owners", x => x.OwnerId);
                });

            migrationBuilder.CreateTable(
                name: "accounts",
                columns: table => new
                {
                    AccountId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    AccountType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    OwnerId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_accounts", x => x.AccountId);
                    table.ForeignKey(
                        name: "FK_accounts_owners_OwnerId",
                        column: x => x.OwnerId,
                        principalTable: "owners",
                        principalColumn: "OwnerId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "owners",
                columns: new[] { "OwnerId", "Address", "DateOfBirth", "Name" },
                values: new object[,]
                {
                    { 1, "123 Main St", new DateTime(1978, 3, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), "John Doe" },
                    { 2, "456 Elm St", new DateTime(1985, 7, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Jane Smith" },
                    { 3, "789 Oak St", new DateTime(1970, 11, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "Bob Johnson" },
                    { 4, "1010 Maple Ave", new DateTime(1992, 9, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "Sarah Lee" }
                });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "AccountId", "AccountType", "DateCreated", "OwnerId" },
                values: new object[,]
                {
                    { 1, "Domestic", new DateTime(2003, 12, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 2, "Domestic", new DateTime(1996, 2, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { 3, "Domestic", new DateTime(1999, 5, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), 3 },
                    { 4, "Savings", new DateTime(1999, 12, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), 3 },
                    { 5, "Domestic", new DateTime(2010, 5, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), 4 },
                    { 6, "Foreign", new DateTime(1999, 5, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), 3 },
                    { 7, "Foreign", new DateTime(1996, 2, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { 8, "Foreign", new DateTime(2010, 6, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), 4 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_accounts_OwnerId",
                table: "accounts",
                column: "OwnerId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "accounts");

            migrationBuilder.DropTable(
                name: "owners");
        }
    }
}
