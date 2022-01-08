using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LAB_3.Migrations
{
    public partial class MigrationData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Authors",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    DateOfBirth = table.Column<DateTime>(type: "date", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Authors", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Genres",
                columns: table => new
                {
                    Genre_ID = table.Column<int>(type: "int", nullable: false),
                    Genre = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Genres", x => x.Genre_ID);
                });

            migrationBuilder.CreateTable(
                name: "Publishers",
                columns: table => new
                {
                    Publisher_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Publischer_Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Publisher_Address = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Telephone_Number = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Publishers", x => x.Publisher_ID);
                });

            migrationBuilder.CreateTable(
                name: "Shops",
                columns: table => new
                {
                    Shop_ID = table.Column<string>(type: "nvarchar(6)", maxLength: 6, nullable: false),
                    Shop_Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Shop_Address = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Shop_Town = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Shop_ContactNumber = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Shops", x => x.Shop_ID);
                });

            migrationBuilder.CreateTable(
                name: "Books",
                columns: table => new
                {
                    ISBN_ID = table.Column<string>(type: "nvarchar(13)", maxLength: 13, nullable: false),
                    Title = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Language = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Page_Numbers = table.Column<int>(type: "int", nullable: true),
                    PriceSEK = table.Column<decimal>(name: "Price(SEK)", type: "money", nullable: true),
                    Release_Date = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Author_ID = table.Column<int>(type: "int", nullable: true),
                    Genre_ID = table.Column<int>(type: "int", nullable: true),
                    Publishers_ID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Books__7C97DF4A77FDA38E", x => x.ISBN_ID);
                    table.ForeignKey(
                        name: "FK__Books__Author_ID__300424B4",
                        column: x => x.Author_ID,
                        principalTable: "Authors",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK__Books__Genre_ID__30F848ED",
                        column: x => x.Genre_ID,
                        principalTable: "Genres",
                        principalColumn: "Genre_ID");
                    table.ForeignKey(
                        name: "FK__Books__Publisher__2F10007B",
                        column: x => x.Publishers_ID,
                        principalTable: "Publishers",
                        principalColumn: "Publisher_ID");
                });

            migrationBuilder.CreateTable(
                name: "Inventory",
                columns: table => new
                {
                    Shop_ID = table.Column<string>(type: "nvarchar(6)", maxLength: 6, nullable: false),
                    ISBN_ID = table.Column<string>(type: "nvarchar(13)", maxLength: 13, nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Inventor__EBC1EB24AF647E4E", x => new { x.Shop_ID, x.ISBN_ID });
                    table.ForeignKey(
                        name: "FK__Inventory__Quant__2C3393D0",
                        column: x => x.ISBN_ID,
                        principalTable: "Books",
                        principalColumn: "ISBN_ID");
                    table.ForeignKey(
                        name: "FK__Inventory__Shop___31EC6D26",
                        column: x => x.Shop_ID,
                        principalTable: "Shops",
                        principalColumn: "Shop_ID");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Books_Author_ID",
                table: "Books",
                column: "Author_ID");

            migrationBuilder.CreateIndex(
                name: "IX_Books_Genre_ID",
                table: "Books",
                column: "Genre_ID");

            migrationBuilder.CreateIndex(
                name: "IX_Books_Publishers_ID",
                table: "Books",
                column: "Publishers_ID");

            migrationBuilder.CreateIndex(
                name: "Inventory",
                table: "Inventory",
                columns: new[] { "Shop_ID", "ISBN_ID" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Inventory_ISBN_ID",
                table: "Inventory",
                column: "ISBN_ID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Inventory");

            migrationBuilder.DropTable(
                name: "Books");

            migrationBuilder.DropTable(
                name: "Shops");

            migrationBuilder.DropTable(
                name: "Authors");

            migrationBuilder.DropTable(
                name: "Genres");

            migrationBuilder.DropTable(
                name: "Publishers");
        }
    }
}
