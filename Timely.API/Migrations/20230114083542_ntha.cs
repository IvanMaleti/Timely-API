using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Timely.API.Migrations
{
    /// <inheritdoc />
    public partial class ntha : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "EndTimeDate",
                table: "ProjEntries");

            migrationBuilder.DropColumn(
                name: "StartTimeDate",
                table: "ProjEntries");

            migrationBuilder.AddColumn<long>(
                name: "EndTimeDateMilisec",
                table: "ProjEntries",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<long>(
                name: "StartTimeDateMilisec",
                table: "ProjEntries",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "EndTimeDateMilisec",
                table: "ProjEntries");

            migrationBuilder.DropColumn(
                name: "StartTimeDateMilisec",
                table: "ProjEntries");

            migrationBuilder.AddColumn<DateTime>(
                name: "EndTimeDate",
                table: "ProjEntries",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "StartTimeDate",
                table: "ProjEntries",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }
    }
}
