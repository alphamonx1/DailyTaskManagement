using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DailyTaskManagement.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class UpdateItemStatus : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TodoItem_ItemStatuses_ItemStatusId",
                table: "TodoItem");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ItemStatuses",
                table: "ItemStatuses");

            migrationBuilder.RenameTable(
                name: "ItemStatuses",
                newName: "ItemStatus");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ItemStatus",
                table: "ItemStatus",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_TodoItem_ItemStatus_ItemStatusId",
                table: "TodoItem",
                column: "ItemStatusId",
                principalTable: "ItemStatus",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TodoItem_ItemStatus_ItemStatusId",
                table: "TodoItem");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ItemStatus",
                table: "ItemStatus");

            migrationBuilder.RenameTable(
                name: "ItemStatus",
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
    }
}
