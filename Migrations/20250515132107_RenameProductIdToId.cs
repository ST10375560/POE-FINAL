using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AgriEnergyConnectWebApp.Migrations
{
    /// <summary>
    /// Migration to rename the primary key column in the Products table
    /// from "ProductId" to "Id", and to add maximum length constraints to
    /// the "Name" and "Category" fields.
    /// </summary>
    public partial class RenameProductIdToId : Migration
    {
        /// <summary>
        /// Applies the schema changes to the database.
        /// </summary>
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            // Rename the primary key column from "ProductId" to "Id" in the "Products" table
            migrationBuilder.RenameColumn(
                name: "ProductId",
                table: "Products",
                newName: "Id");

            // Modify the "Name" column to have a max length of 100 characters
            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Products",
                type: "character varying(100)", // PostgreSQL-specific VARCHAR type
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text"); // Previous type had no length constraint

            // Modify the "Category" column to have a max length of 50 characters
            migrationBuilder.AlterColumn<string>(
                name: "Category",
                table: "Products",
                type: "character varying(50)", // PostgreSQL-specific VARCHAR type
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text"); // Previous type had no length constraint
        }

        /// <summary>
        /// Reverts the schema changes applied in the Up method.
        /// </summary>
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            // Revert the column name back to "ProductId"
            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Products",
                newName: "ProductId");

            // Revert "Name" column back to unbounded text type
            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Products",
                type: "text",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(100)",
                oldMaxLength: 100);

            // Revert "Category" column back to unbounded text type
            migrationBuilder.AlterColumn<string>(
                name: "Category",
                table: "Products",
                type: "text",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(50)",
                oldMaxLength: 50);
        }
    }
}
