using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Shop.Migrations
{
    /// <inheritdoc />
    public partial class UpdatedNameOfOrderLinesEntity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OrderLine_AppOrders_OrderId",
                table: "OrderLine");

            migrationBuilder.DropPrimaryKey(
                name: "PK_OrderLine",
                table: "OrderLine");

            migrationBuilder.RenameTable(
                name: "OrderLine",
                newName: "AppOrderLines");

            migrationBuilder.AddPrimaryKey(
                name: "PK_AppOrderLines",
                table: "AppOrderLines",
                columns: new[] { "OrderId", "ProductId" });

            migrationBuilder.AddForeignKey(
                name: "FK_AppOrderLines_AppOrders_OrderId",
                table: "AppOrderLines",
                column: "OrderId",
                principalTable: "AppOrders",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AppOrderLines_AppOrders_OrderId",
                table: "AppOrderLines");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AppOrderLines",
                table: "AppOrderLines");

            migrationBuilder.RenameTable(
                name: "AppOrderLines",
                newName: "OrderLine");

            migrationBuilder.AddPrimaryKey(
                name: "PK_OrderLine",
                table: "OrderLine",
                columns: new[] { "OrderId", "ProductId" });

            migrationBuilder.AddForeignKey(
                name: "FK_OrderLine_AppOrders_OrderId",
                table: "OrderLine",
                column: "OrderId",
                principalTable: "AppOrders",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
