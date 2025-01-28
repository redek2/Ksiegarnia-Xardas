using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Księgarnia_Xardas.Migrations
{
    /// <inheritdoc />
    public partial class AddDateDueToBorrow : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "DateDue",
                table: "Borrows",
                type: "datetime2",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DateDue",
                table: "Borrows");
        }
    }
}
