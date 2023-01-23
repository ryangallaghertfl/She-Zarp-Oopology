using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Oopology.Migrations
{
    /// <inheritdoc />
    public partial class PurchasesRelationWithUser : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "UserId",
                table: "Purchase",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Purchase_UserId",
                table: "Purchase",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Purchase_User_UserId",
                table: "Purchase",
                column: "UserId",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Purchase_User_UserId",
                table: "Purchase");

            migrationBuilder.DropIndex(
                name: "IX_Purchase_UserId",
                table: "Purchase");

            migrationBuilder.AlterColumn<int>(
                name: "UserId",
                table: "Purchase",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");
        }
    }
}
