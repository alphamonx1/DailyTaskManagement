using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DailyTaskManagement.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class UpdateCorrectMistake : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TodoItem_TtemStatuses_ItemStatusId",
                table: "TodoItem");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TtemStatuses",
                table: "TtemStatuses");

            migrationBuilder.RenameTable(
                name: "TtemStatuses",
                newName: "ItemStatuses");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ItemStatuses",
                table: "ItemStatuses",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_TodoItem_ItemStatuses_ItemStatusId",
                table: "TodoItem",
                column: "ItemStatusId",
                principalTable: "ItemStatuses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TodoItem_ItemStatuses_ItemStatusId",
                table: "TodoItem");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ItemStatuses",
                table: "ItemStatuses");

            migrationBuilder.RenameTable(
                name: "ItemStatuses",
                newName: "TtemStatuses");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TtemStatuses",
                table: "TtemStatuses",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_TodoItem_TtemStatuses_ItemStatusId",
                table: "TodoItem",
                column: "ItemStatusId",
                principalTable: "TtemStatuses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
