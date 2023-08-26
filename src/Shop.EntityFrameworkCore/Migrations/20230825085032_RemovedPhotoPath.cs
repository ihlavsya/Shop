using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Shop.Migrations
{
    /// <inheritdoc />
    public partial class RemovedPhotoPath : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_AbpClaimtypes",
                table: "AbpClaimtypes");

            migrationBuilder.DropColumn(
                name: "PhotoPath",
                table: "AppProducts");

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
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
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

            migrationBuilder.AddColumn<string>(
                name: "PhotoPath",
                table: "AppProducts",
                type: "nvarchar(1000)",
                maxLength: 1000,
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_AbpClaimtypes",
                table: "AbpClaimtypes",
                column: "Id");
        }
    }
}
