using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LoopsChallenge.Data.Migrations
{
    public partial class ChangeTagFormat : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tag_Review_ReviewId",
                table: "Tag");

            migrationBuilder.DropIndex(
                name: "IX_Tag_ReviewId",
                table: "Tag");

            migrationBuilder.DropColumn(
                name: "ReviewId",
                table: "Tag");

            migrationBuilder.AlterColumn<string>(
                name: "NormalizedTagText",
                table: "Tag",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<string>(
                name: "SerializedTags",
                table: "Review",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_Tag_NormalizedTagText",
                table: "Tag",
                column: "NormalizedTagText",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Tag_NormalizedTagText",
                table: "Tag");

            migrationBuilder.DropColumn(
                name: "SerializedTags",
                table: "Review");

            migrationBuilder.AlterColumn<string>(
                name: "NormalizedTagText",
                table: "Tag",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddColumn<int>(
                name: "ReviewId",
                table: "Tag",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Tag_ReviewId",
                table: "Tag",
                column: "ReviewId");

            migrationBuilder.AddForeignKey(
                name: "FK_Tag_Review_ReviewId",
                table: "Tag",
                column: "ReviewId",
                principalTable: "Review",
                principalColumn: "Id");
        }
    }
}
