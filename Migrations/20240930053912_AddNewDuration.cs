using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Zara_GestionDVD.Migrations
{
    /// <inheritdoc />
    public partial class AddNewDuration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Duree",
                table: "DVDs");

            migrationBuilder.AddColumn<int>(
                name: "DureeHeures",
                table: "DVDs",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "DureeMinutes",
                table: "DVDs",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DureeHeures",
                table: "DVDs");

            migrationBuilder.DropColumn(
                name: "DureeMinutes",
                table: "DVDs");

            migrationBuilder.AddColumn<TimeSpan>(
                name: "Duree",
                table: "DVDs",
                type: "TEXT",
                nullable: false,
                defaultValue: new TimeSpan(0, 0, 0, 0, 0));
        }
    }
}
