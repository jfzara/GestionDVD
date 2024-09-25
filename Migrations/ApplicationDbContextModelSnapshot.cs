﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Zara_GestionDVD.Data;

#nullable disable

namespace Zara_GestionDVD.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "8.0.8");

            modelBuilder.Entity("Zara_GestionDVD.Models.Categorie", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Nom")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Categories");
                });

            modelBuilder.Entity("Zara_GestionDVD.Models.DVD", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("ActeursPrincipaux")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("AnneeSortie")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Categorie")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("DerniereMiseAJour")
                        .HasColumnType("TEXT");

                    b.Property<string>("DerniereMiseAJourPar")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("DescriptionSuppléments")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<TimeSpan>("Duree")
                        .HasColumnType("TEXT");

                    b.Property<int>("EmprunteurId")
                        .HasColumnType("INTEGER");

                    b.Property<bool>("EstDVDOriginal")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Format")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("LanguesDisponibles")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("NomProducteur")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("NomRealisateur")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("NombreDisques")
                        .HasColumnType("INTEGER");

                    b.Property<int>("PropriétaireId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("ResumeFilm")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("SousTitresDisponibles")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("TitreFrancais")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("TitreOriginal")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("UtilisateurId")
                        .HasColumnType("TEXT");

                    b.Property<bool>("VersionEtendue")
                        .HasColumnType("INTEGER");

                    b.Property<bool>("VisibleATous")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("UtilisateurId");

                    b.ToTable("DVDs");
                });

            modelBuilder.Entity("Zara_GestionDVD.Models.Historique", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("DVDId")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("DateEmprunt")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("DateRetour")
                        .HasColumnType("TEXT");

                    b.Property<string>("UtilisateurId")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Historiques");
                });

            modelBuilder.Entity("Zara_GestionDVD.Models.Message", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Corps")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("DateEnvoi")
                        .HasColumnType("TEXT");

                    b.Property<string>("DestinataireId")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("ExpediteurId")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Sujet")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Messages");
                });

            modelBuilder.Entity("Zara_GestionDVD.Models.Utilisateur", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("TEXT");

                    b.Property<string>("Courriel")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("MotDePasse")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<bool>("NotificationsActives")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Prenom")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Utilisateurs");
                });

            modelBuilder.Entity("Zara_GestionDVD.Models.DVD", b =>
                {
                    b.HasOne("Zara_GestionDVD.Models.Utilisateur", null)
                        .WithMany("DVDsPossedes")
                        .HasForeignKey("UtilisateurId");
                });

            modelBuilder.Entity("Zara_GestionDVD.Models.Utilisateur", b =>
                {
                    b.Navigation("DVDsPossedes");
                });
#pragma warning restore 612, 618
        }
    }
}
