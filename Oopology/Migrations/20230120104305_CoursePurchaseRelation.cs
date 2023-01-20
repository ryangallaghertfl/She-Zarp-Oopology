using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Oopology.Migrations
{
    /// <inheritdoc />
    public partial class CoursePurchaseRelation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "CourseId",
                table: "Purchase",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Purchase_CourseId",
                table: "Purchase",
                column: "CourseId");

            migrationBuilder.AddForeignKey(
                name: "FK_Purchase_Course_CourseId",
                table: "Purchase",
                column: "CourseId",
                principalTable: "Course",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Purchase_Course_CourseId",
                table: "Purchase");

            migrationBuilder.DropIndex(
                name: "IX_Purchase_CourseId",
                table: "Purchase");

            migrationBuilder.AlterColumn<int>(
                name: "CourseId",
                table: "Purchase",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");
        }
    }
}
