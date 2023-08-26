using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Shop.Migrations
{
    /// <inheritdoc />
    public partial class AddedDatabaseModule1172 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_AbpClaimtypes",
                table: "AbpClaimtypes");

            migrationBuilder.RenameTable(
                name: "AbpClaimtypes",
                newName: "AbpClaimTypes");

            migrationBuilder.RenameColumn(
                name: "type",
                table: "OpenIddictTokens",
                newName: "Type");

            migrationBuilder.RenameIndex(
                name: "IX_OpenIddictTokens_ApplicationId_Status_Subject_type",
                table: "OpenIddictTokens",
                newName: "IX_OpenIddictTokens_ApplicationId_Status_Subject_Type");

            migrationBuilder.RenameColumn(
                name: "type",
                table: "OpenIddictAuthorizations",
                newName: "Type");

            migrationBuilder.RenameIndex(
                name: "IX_OpenIddictAuthorizations_ApplicationId_Status_Subject_type",
                table: "OpenIddictAuthorizations",
                newName: "IX_OpenIddictAuthorizations_ApplicationId_Status_Subject_Type");

            migrationBuilder.RenameColumn(
                name: "type",
                table: "OpenIddictApplications",
                newName: "Type");

            migrationBuilder.RenameColumn(
                name: "Consenttype",
                table: "OpenIddictApplications",
                newName: "ConsentType");

            migrationBuilder.RenameColumn(
                name: "Claimtype",
                table: "AbpUserClaims",
                newName: "ClaimType");

            migrationBuilder.RenameColumn(
                name: "Claimtype",
                table: "AbpRoleClaims",
                newName: "ClaimType");

            migrationBuilder.RenameColumn(
                name: "Valuetype",
                table: "AbpFeatures",
                newName: "ValueType");

            migrationBuilder.RenameColumn(
                name: "PropertytypeFullName",
                table: "AbpEntityPropertyChanges",
                newName: "PropertyTypeFullName");

            migrationBuilder.RenameColumn(
                name: "EntitytypeFullName",
                table: "AbpEntityChanges",
                newName: "EntityTypeFullName");

            migrationBuilder.RenameColumn(
                name: "Changetype",
                table: "AbpEntityChanges",
                newName: "ChangeType");

            migrationBuilder.RenameIndex(
                name: "IX_AbpEntityChanges_TenantId_EntitytypeFullName_EntityId",
                table: "AbpEntityChanges",
                newName: "IX_AbpEntityChanges_TenantId_EntityTypeFullName_EntityId");

            migrationBuilder.RenameColumn(
                name: "Valuetype",
                table: "AbpClaimTypes",
                newName: "ValueType");

            migrationBuilder.AlterColumn<int>(
                name: "EntityVersion",
                table: "AppProducts",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldDefaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_AbpClaimTypes",
                table: "AbpClaimTypes",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "AbpBlobContainers",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TenantId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    ExtraProperties = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AbpBlobContainers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AbpBlobs",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ContainerId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TenantId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false),
                    Content = table.Column<byte[]>(type: "varbinary(max)", maxLength: 2147483647, nullable: true),
                    ExtraProperties = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AbpBlobs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AbpBlobs_AbpBlobContainers_ContainerId",
                        column: x => x.ContainerId,
                        principalTable: "AbpBlobContainers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AbpBlobContainers_TenantId_Name",
                table: "AbpBlobContainers",
                columns: new[] { "TenantId", "Name" });

            migrationBuilder.CreateIndex(
                name: "IX_AbpBlobs_ContainerId",
                table: "AbpBlobs",
                column: "ContainerId");

            migrationBuilder.CreateIndex(
                name: "IX_AbpBlobs_TenantId_ContainerId_Name",
                table: "AbpBlobs",
                columns: new[] { "TenantId", "ContainerId", "Name" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AbpBlobs");

            migrationBuilder.DropTable(
                name: "AbpBlobContainers");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AbpClaimTypes",
                table: "AbpClaimTypes");

            migrationBuilder.RenameTable(
                name: "AbpClaimTypes",
                newName: "AbpClaimtypes");

            migrationBuilder.RenameColumn(
                name: "Type",
                table: "OpenIddictTokens",
                newName: "type");

            migrationBuilder.RenameIndex(
                name: "IX_OpenIddictTokens_ApplicationId_Status_Subject_Type",
                table: "OpenIddictTokens",
                newName: "IX_OpenIddictTokens_ApplicationId_Status_Subject_type");

            migrationBuilder.RenameColumn(
                name: "Type",
                table: "OpenIddictAuthorizations",
                newName: "type");

            migrationBuilder.RenameIndex(
                name: "IX_OpenIddictAuthorizations_ApplicationId_Status_Subject_Type",
                table: "OpenIddictAuthorizations",
                newName: "IX_OpenIddictAuthorizations_ApplicationId_Status_Subject_type");

            migrationBuilder.RenameColumn(
                name: "Type",
                table: "OpenIddictApplications",
                newName: "type");

            migrationBuilder.RenameColumn(
                name: "ConsentType",
                table: "OpenIddictApplications",
                newName: "Consenttype");

            migrationBuilder.RenameColumn(
                name: "ClaimType",
                table: "AbpUserClaims",
                newName: "Claimtype");

            migrationBuilder.RenameColumn(
                name: "ClaimType",
                table: "AbpRoleClaims",
                newName: "Claimtype");

            migrationBuilder.RenameColumn(
                name: "ValueType",
                table: "AbpFeatures",
                newName: "Valuetype");

            migrationBuilder.RenameColumn(
                name: "PropertyTypeFullName",
                table: "AbpEntityPropertyChanges",
                newName: "PropertytypeFullName");

            migrationBuilder.RenameColumn(
                name: "EntityTypeFullName",
                table: "AbpEntityChanges",
                newName: "EntitytypeFullName");

            migrationBuilder.RenameColumn(
                name: "ChangeType",
                table: "AbpEntityChanges",
                newName: "Changetype");

            migrationBuilder.RenameIndex(
                name: "IX_AbpEntityChanges_TenantId_EntityTypeFullName_EntityId",
                table: "AbpEntityChanges",
                newName: "IX_AbpEntityChanges_TenantId_EntitytypeFullName_EntityId");

            migrationBuilder.RenameColumn(
                name: "ValueType",
                table: "AbpClaimtypes",
                newName: "Valuetype");

            migrationBuilder.AlterColumn<int>(
                name: "EntityVersion",
                table: "AppProducts",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddPrimaryKey(
                name: "PK_AbpClaimtypes",
                table: "AbpClaimtypes",
                column: "Id");
        }
    }
}
