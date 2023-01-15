using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Timely.API.Migrations
{
    /// <inheritdoc />
    public partial class SecondMig : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_newProjEntries",
                table: "newProjEntries");

            migrationBuilder.RenameTable(
                name: "newProjEntries",
                newName: "ProjEntries");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ProjEntries",
                table: "ProjEntries",
                column: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_ProjEntries",
                table: "ProjEntries");

            migrationBuilder.RenameTable(
                name: "ProjEntries",
                newName: "newProjEntries");

            migrationBuilder.AddPrimaryKey(
                name: "PK_newProjEntries",
                table: "newProjEntries",
                column: "Id");
        }
    }
}
