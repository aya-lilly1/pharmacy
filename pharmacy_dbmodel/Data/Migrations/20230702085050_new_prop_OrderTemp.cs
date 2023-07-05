using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace pharmacy_DbModel.Data.Migrations
{
    /// <inheritdoc />
    public partial class new_prop_OrderTemp : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "OrderAt",
                table: "TempOrders",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "TempOrders",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_TempOrders_UserId",
                table: "TempOrders",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_TempOrders_AspNetUsers_UserId",
                table: "TempOrders",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TempOrders_AspNetUsers_UserId",
                table: "TempOrders");

            migrationBuilder.DropIndex(
                name: "IX_TempOrders_UserId",
                table: "TempOrders");

            migrationBuilder.DropColumn(
                name: "OrderAt",
                table: "TempOrders");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "TempOrders");
        }
    }
}
