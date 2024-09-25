using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Zara_GestionDVD.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Nom = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Historiques",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    DVDId = table.Column<int>(type: "INTEGER", nullable: false),
                    UtilisateurId = table.Column<string>(type: "TEXT", nullable: false),
                    DateEmprunt = table.Column<DateTime>(type: "TEXT", nullable: false),
                    DateRetour = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Historiques", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Messages",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    ExpediteurId = table.Column<string>(type: "TEXT", nullable: false),
                    DestinataireId = table.Column<string>(type: "TEXT", nullable: false),
                    Sujet = table.Column<string>(type: "TEXT", nullable: false),
                    Corps = table.Column<string>(type: "TEXT", nullable: false),
                    DateEnvoi = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Messages", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Utilisateurs",
                columns: table => new
                {
                    Id = table.Column<string>(type: "TEXT", nullable: false),
                    Prenom = table.Column<string>(type: "TEXT", nullable: false),
                    Courriel = table.Column<string>(type: "TEXT", nullable: false),
                    MotDePasse = table.Column<string>(type: "TEXT", nullable: false),
                    NotificationsActives = table.Column<bool>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Utilisateurs", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DVDs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    TitreFrancais = table.Column<string>(type: "TEXT", nullable: false),
                    TitreOriginal = table.Column<string>(type: "TEXT", nullable: false),
                    AnneeSortie = table.Column<int>(type: "INTEGER", nullable: false),
                    Categorie = table.Column<string>(type: "TEXT", nullable: false),
                    DerniereMiseAJour = table.Column<DateTime>(type: "TEXT", nullable: false),
                    DerniereMiseAJourPar = table.Column<string>(type: "TEXT", nullable: false),
                    DescriptionSuppléments = table.Column<string>(type: "TEXT", nullable: false),
                    Duree = table.Column<TimeSpan>(type: "TEXT", nullable: false),
                    EstDVDOriginal = table.Column<bool>(type: "INTEGER", nullable: false),
                    Format = table.Column<string>(type: "TEXT", nullable: false),
                    LanguesDisponibles = table.Column<string>(type: "TEXT", nullable: false),
                    NombreDisques = table.Column<int>(type: "INTEGER", nullable: false),
                    NomProducteur = table.Column<string>(type: "TEXT", nullable: false),
                    NomRealisateur = table.Column<string>(type: "TEXT", nullable: false),
                    ActeursPrincipaux = table.Column<string>(type: "TEXT", nullable: false),
                    ResumeFilm = table.Column<string>(type: "TEXT", nullable: false),
                    SousTitresDisponibles = table.Column<string>(type: "TEXT", nullable: false),
                    PropriétaireId = table.Column<int>(type: "INTEGER", nullable: false),
                    EmprunteurId = table.Column<int>(type: "INTEGER", nullable: false),
                    VersionEtendue = table.Column<bool>(type: "INTEGER", nullable: false),
                    VisibleATous = table.Column<bool>(type: "INTEGER", nullable: false),
                    UtilisateurId = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DVDs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DVDs_Utilisateurs_UtilisateurId",
                        column: x => x.UtilisateurId,
                        principalTable: "Utilisateurs",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_DVDs_UtilisateurId",
                table: "DVDs",
                column: "UtilisateurId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropTable(
                name: "DVDs");

            migrationBuilder.DropTable(
                name: "Historiques");

            migrationBuilder.DropTable(
                name: "Messages");

            migrationBuilder.DropTable(
                name: "Utilisateurs");
        }
    }
}
