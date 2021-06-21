using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TransactionImportAPI.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Transactions",
                columns: table => new
                {
                    TransactionIdentifier = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    TransactionAmount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    TransactionDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Transactions", x => x.TransactionIdentifier);
                });

            migrationBuilder.CreateTable(
                name: "Countries",
                columns: table => new
                {
                    ISOCodeID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ISOCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CountryName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TransactionIdentifier = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Countries", x => x.ISOCodeID);
                    table.ForeignKey(
                        name: "FK_Countries_Transactions_TransactionIdentifier",
                        column: x => x.TransactionIdentifier,
                        principalTable: "Transactions",
                        principalColumn: "TransactionIdentifier",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "TransactionStatuses",
                columns: table => new
                {
                    TransactionStatusId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TransactionStatusType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TransactionIdentifier = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TransactionStatuses", x => x.TransactionStatusId);
                    table.ForeignKey(
                        name: "FK_TransactionStatuses_Transactions_TransactionIdentifier",
                        column: x => x.TransactionIdentifier,
                        principalTable: "Transactions",
                        principalColumn: "TransactionIdentifier",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Countries_TransactionIdentifier",
                table: "Countries",
                column: "TransactionIdentifier");

            migrationBuilder.CreateIndex(
                name: "IX_TransactionStatuses_TransactionIdentifier",
                table: "TransactionStatuses",
                column: "TransactionIdentifier");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Countries");

            migrationBuilder.DropTable(
                name: "TransactionStatuses");

            migrationBuilder.DropTable(
                name: "Transactions");
        }
    }
}
