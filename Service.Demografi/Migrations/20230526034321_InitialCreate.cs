using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Service.Demografi.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Demografis",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NIK = table.Column<long>(nullable: false),
                    Nama = table.Column<string>(nullable: true),
                    Tempat_Lahir = table.Column<string>(nullable: true),
                    Tanggal_Lahir = table.Column<DateTime>(nullable: false),
                    Jenis_Kelamin = table.Column<string>(nullable: true),
                    Golongan_Darah = table.Column<string>(nullable: true),
                    Alamat = table.Column<string>(nullable: true),
                    RT = table.Column<string>(nullable: true),
                    RW = table.Column<string>(nullable: true),
                    Kelurahan = table.Column<string>(nullable: true),
                    Desa = table.Column<string>(nullable: true),
                    Kecamatan = table.Column<string>(nullable: true),
                    Kota = table.Column<string>(nullable: true),
                    Provinsi = table.Column<string>(nullable: true),
                    Agama = table.Column<string>(nullable: true),
                    KodePos = table.Column<string>(nullable: true),
                    StatusPerkawinan = table.Column<string>(nullable: true),
                    Pekerjaan = table.Column<string>(nullable: true),
                    Kewarganegaraan = table.Column<string>(nullable: true),
                    Masa_Berlaku = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Demografis", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PhotoIDs",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NIK = table.Column<long>(nullable: false),
                    Path_Photo = table.Column<string>(nullable: true),
                    DemografiId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PhotoIDs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PhotoIDs_Demografis_DemografiId",
                        column: x => x.DemografiId,
                        principalTable: "Demografis",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PhotoIDs_DemografiId",
                table: "PhotoIDs",
                column: "DemografiId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PhotoIDs");

            migrationBuilder.DropTable(
                name: "Demografis");
        }
    }
}
