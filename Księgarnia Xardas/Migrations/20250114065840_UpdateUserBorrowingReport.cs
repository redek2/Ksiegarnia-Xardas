using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Księgarnia_Xardas.Migrations
{
    /// <inheritdoc />
    public partial class UpdateUserBorrowingReport : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            // Usuń klucz główny, który jest zależny od kolumny 'Id'
            migrationBuilder.DropPrimaryKey(
                name: "PK_UserBorrowingReports",
                table: "UserBorrowingReports");

            // Usuwamy kolumnę 'Id' z tabeli 'UserBorrowingReports'
            migrationBuilder.DropColumn(
                name: "Id",
                table: "UserBorrowingReports");

            // Dalsze zmiany kolumn w tabeli 'UserBorrowingReports'
            migrationBuilder.DropColumn(
                name: "Amount",
                table: "UserBorrowingReports");

            migrationBuilder.RenameColumn(
                name: "Status",
                table: "UserBorrowingReports",
                newName: "Title");

            migrationBuilder.RenameColumn(
                name: "ReturnedAt",
                table: "UserBorrowingReports",
                newName: "ReturnDate");

            migrationBuilder.RenameColumn(
                name: "BorrowedAt",
                table: "UserBorrowingReports",
                newName: "BorrowDate");

            // Zmiana typu kolumny 'UserId' na string
            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "UserBorrowingReports",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            // Dodanie nowej kolumny 'DateDue'
            migrationBuilder.AddColumn<DateTime>(
                name: "DateDue",
                table: "UserBorrowingReports",
                type: "datetime2",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            // Wrócenie poprzednich zmian: dodanie kolumny 'Id'
            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "UserBorrowingReports",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            // Usuwamy kolumnę 'DateDue'
            migrationBuilder.DropColumn(
                name: "DateDue",
                table: "UserBorrowingReports");

            // Przywrócenie nazw kolumn
            migrationBuilder.RenameColumn(
                name: "Title",
                table: "UserBorrowingReports",
                newName: "Status");

            migrationBuilder.RenameColumn(
                name: "ReturnDate",
                table: "UserBorrowingReports",
                newName: "ReturnedAt");

            migrationBuilder.RenameColumn(
                name: "BorrowDate",
                table: "UserBorrowingReports",
                newName: "BorrowedAt");

            // Przywrócenie typu 'UserId' na 'int'
            migrationBuilder.AlterColumn<int>(
                name: "UserId",
                table: "UserBorrowingReports",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            // Przywracamy klucz główny
            migrationBuilder.AddPrimaryKey(
                name: "PK_UserBorrowingReports",
                table: "UserBorrowingReports",
                column: "Id");
        }
    }
}
