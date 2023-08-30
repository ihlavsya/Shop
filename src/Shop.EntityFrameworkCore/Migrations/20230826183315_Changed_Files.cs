using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Shop.Migrations
{
    /// <inheritdoc />
    public partial class ChangedFiles : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AppFiles_AppProducts_IdProduct",
                table: "AppFiles");

            migrationBuilder.DropForeignKey(
                name: "FK_AppFiles_AppProducts_ProductId",
                table: "AppFiles");

            migrationBuilder.DropIndex(
                name: "IX_AppFiles_IdProduct",
                table: "AppFiles");

            migrationBuilder.DropColumn(
                name: "IdProduct",
                table: "AppFiles");

            migrationBuilder.AlterColumn<Guid>(
                name: "ProductId",
                table: "AppFiles",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_AppFiles_AppProducts_ProductId",
                table: "AppFiles",
                column: "ProductId",
                principalTable: "AppProducts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AppFiles_AppProducts_ProductId",
                table: "AppFiles");

            migrationBuilder.AlterColumn<Guid>(
                name: "ProductId",
                table: "AppFiles",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AddColumn<Guid>(
                name: "IdProduct",
                table: "AppFiles",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_AppFiles_IdProduct",
                table: "AppFiles",
                column: "IdProduct");

            migrationBuilder.AddForeignKey(
                name: "FK_AppFiles_AppProducts_IdProduct",
                table: "AppFiles",
                column: "IdProduct",
                principalTable: "AppProducts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AppFiles_AppProducts_ProductId",
                table: "AppFiles",
                column: "ProductId",
                principalTable: "AppProducts",
                principalColumn: "Id");
        }
    }
}
