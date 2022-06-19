using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace UDPListener.Data.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "IPAddresses",
                columns: table => new
                {
                    IPAddressId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IP = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IPAddresses", x => x.IPAddressId);
                });

            migrationBuilder.CreateTable(
                name: "Messages",
                columns: table => new
                {
                    MessageId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    MessageText = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: false),
                    IPAddressId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Messages", x => x.MessageId);
                    table.ForeignKey(
                        name: "FK_Messages_IPAddresses_IPAddressId",
                        column: x => x.IPAddressId,
                        principalTable: "IPAddresses",
                        principalColumn: "IPAddressId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Messages_IPAddressId",
                table: "Messages",
                column: "IPAddressId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Messages");

            migrationBuilder.DropTable(
                name: "IPAddresses");
        }
    }
}
