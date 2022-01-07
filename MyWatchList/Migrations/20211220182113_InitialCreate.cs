using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MyWatchList.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Acteur",
                columns: table => new
                {
                    ActeurID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Voornaam = table.Column<string>(nullable: false),
                    Achternaam = table.Column<string>(nullable: false),
                    Geboortejaar = table.Column<string>(nullable: true),
                    LandVanHerkomst = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Acteur", x => x.ActeurID);
                });

            migrationBuilder.CreateTable(
                name: "Gebruiker",
                columns: table => new
                {
                    GebruikerID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Voornaam = table.Column<string>(nullable: false),
                    Achternaam = table.Column<string>(nullable: false),
                    Email = table.Column<string>(nullable: false),
                    Wachtwoord = table.Column<string>(nullable: false),
                    Geboortedatum = table.Column<DateTime>(nullable: false),
                    isBeheerder = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Gebruiker", x => x.GebruikerID);
                });

            migrationBuilder.CreateTable(
                name: "Maker",
                columns: table => new
                {
                    MakerID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Voornaam = table.Column<string>(nullable: true),
                    Achternaam = table.Column<string>(nullable: true),
                    Geboortejaar = table.Column<string>(nullable: true),
                    LandVanHerkomst = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Maker", x => x.MakerID);
                });

            migrationBuilder.CreateTable(
                name: "Serie",
                columns: table => new
                {
                    SerieID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Titel = table.Column<string>(nullable: false),
                    JaarVanUitkomst = table.Column<string>(nullable: false),
                    AantalSeizoenen = table.Column<int>(nullable: false),
                    MinimumLeeftijd = table.Column<string>(nullable: true),
                    CoverImg = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Serie", x => x.SerieID);
                });

            migrationBuilder.CreateTable(
                name: "GebruikerSerie",
                columns: table => new
                {
                    GebruikerSerieID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    GebruikerID = table.Column<int>(nullable: false),
                    SerieID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GebruikerSerie", x => x.GebruikerSerieID);
                    table.ForeignKey(
                        name: "FK_GebruikerSerie_Gebruiker_GebruikerID",
                        column: x => x.GebruikerID,
                        principalTable: "Gebruiker",
                        principalColumn: "GebruikerID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_GebruikerSerie_Serie_SerieID",
                        column: x => x.SerieID,
                        principalTable: "Serie",
                        principalColumn: "SerieID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Maakte",
                columns: table => new
                {
                    MaakteID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MakerID = table.Column<int>(nullable: false),
                    SerieID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Maakte", x => x.MaakteID);
                    table.ForeignKey(
                        name: "FK_Maakte_Maker_MakerID",
                        column: x => x.MakerID,
                        principalTable: "Maker",
                        principalColumn: "MakerID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Maakte_Serie_SerieID",
                        column: x => x.SerieID,
                        principalTable: "Serie",
                        principalColumn: "SerieID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Seizoen",
                columns: table => new
                {
                    SeizoenID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Titel = table.Column<string>(nullable: false),
                    Omschrijving = table.Column<string>(nullable: false),
                    JaarVanUitkomst = table.Column<string>(nullable: false),
                    AantalAfleveringen = table.Column<int>(nullable: false),
                    SerieID = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Seizoen", x => x.SeizoenID);
                    table.ForeignKey(
                        name: "FK_Seizoen_Serie_SerieID",
                        column: x => x.SerieID,
                        principalTable: "Serie",
                        principalColumn: "SerieID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "SpeeltIn",
                columns: table => new
                {
                    SpeeltInID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ActeurID = table.Column<int>(nullable: false),
                    SerieID = table.Column<int>(nullable: false),
                    NaamInSerie = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SpeeltIn", x => x.SpeeltInID);
                    table.ForeignKey(
                        name: "FK_SpeeltIn_Acteur_ActeurID",
                        column: x => x.ActeurID,
                        principalTable: "Acteur",
                        principalColumn: "ActeurID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SpeeltIn_Serie_SerieID",
                        column: x => x.SerieID,
                        principalTable: "Serie",
                        principalColumn: "SerieID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Aflevering",
                columns: table => new
                {
                    AfleveringID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Titel = table.Column<string>(nullable: false),
                    Duur = table.Column<int>(nullable: false),
                    Omschrijving = table.Column<string>(nullable: true),
                    SeizoenID = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Aflevering", x => x.AfleveringID);
                    table.ForeignKey(
                        name: "FK_Aflevering_Seizoen_SeizoenID",
                        column: x => x.SeizoenID,
                        principalTable: "Seizoen",
                        principalColumn: "SeizoenID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Aflevering_SeizoenID",
                table: "Aflevering",
                column: "SeizoenID");

            migrationBuilder.CreateIndex(
                name: "IX_GebruikerSerie_GebruikerID",
                table: "GebruikerSerie",
                column: "GebruikerID");

            migrationBuilder.CreateIndex(
                name: "IX_GebruikerSerie_SerieID",
                table: "GebruikerSerie",
                column: "SerieID");

            migrationBuilder.CreateIndex(
                name: "IX_Maakte_MakerID",
                table: "Maakte",
                column: "MakerID");

            migrationBuilder.CreateIndex(
                name: "IX_Maakte_SerieID",
                table: "Maakte",
                column: "SerieID");

            migrationBuilder.CreateIndex(
                name: "IX_Seizoen_SerieID",
                table: "Seizoen",
                column: "SerieID");

            migrationBuilder.CreateIndex(
                name: "IX_SpeeltIn_ActeurID",
                table: "SpeeltIn",
                column: "ActeurID");

            migrationBuilder.CreateIndex(
                name: "IX_SpeeltIn_SerieID",
                table: "SpeeltIn",
                column: "SerieID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Aflevering");

            migrationBuilder.DropTable(
                name: "GebruikerSerie");

            migrationBuilder.DropTable(
                name: "Maakte");

            migrationBuilder.DropTable(
                name: "SpeeltIn");

            migrationBuilder.DropTable(
                name: "Seizoen");

            migrationBuilder.DropTable(
                name: "Gebruiker");

            migrationBuilder.DropTable(
                name: "Maker");

            migrationBuilder.DropTable(
                name: "Acteur");

            migrationBuilder.DropTable(
                name: "Serie");
        }
    }
}
