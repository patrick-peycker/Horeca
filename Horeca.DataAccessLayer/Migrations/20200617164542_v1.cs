using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Horeca.DataAccessLayer.Migrations
{
    public partial class v1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Identifications",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Type = table.Column<int>(nullable: false),
                    Name = table.Column<string>(maxLength: 50, nullable: false),
                    VatNumber = table.Column<string>(maxLength: 12, nullable: false),
                    EmailAddress = table.Column<string>(maxLength: 255, nullable: false),
                    Description = table.Column<string>(maxLength: 2000, nullable: true),
                    IsValidated = table.Column<bool>(nullable: false),
                    Logo = table.Column<byte[]>(maxLength: 1000000, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Identifications", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Informations",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EmailAddress = table.Column<string>(maxLength: 255, nullable: false),
                    ZipCode = table.Column<string>(maxLength: 20, nullable: false),
                    City = table.Column<string>(maxLength: 100, nullable: false),
                    Country = table.Column<string>(nullable: false),
                    Street = table.Column<string>(maxLength: 100, nullable: false),
                    StreetNumber = table.Column<string>(maxLength: 20, nullable: false),
                    PhoneNumber = table.Column<string>(maxLength: 25, nullable: true),
                    WebSite = table.Column<string>(nullable: true),
                    Instagram = table.Column<string>(nullable: true),
                    Facebook = table.Column<string>(nullable: true),
                    LinkedIn = table.Column<string>(nullable: true),
                    IdentificationId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Informations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Informations_Identifications_IdentificationId",
                        column: x => x.IdentificationId,
                        principalTable: "Identifications",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Shedules",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Day = table.Column<int>(nullable: false),
                    StartAM = table.Column<DateTime>(nullable: false),
                    EndAM = table.Column<DateTime>(nullable: false),
                    StartPM = table.Column<DateTime>(nullable: false),
                    EndPM = table.Column<DateTime>(nullable: false),
                    InformationId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Shedules", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Shedules_Informations_InformationId",
                        column: x => x.InformationId,
                        principalTable: "Informations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Informations_IdentificationId",
                table: "Informations",
                column: "IdentificationId");

            migrationBuilder.CreateIndex(
                name: "IX_Shedules_InformationId",
                table: "Shedules",
                column: "InformationId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Shedules");

            migrationBuilder.DropTable(
                name: "Informations");

            migrationBuilder.DropTable(
                name: "Identifications");
        }
    }
}
