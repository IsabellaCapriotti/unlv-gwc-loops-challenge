using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LoopsChallenge.Data.Migrations
{
    public partial class CompanyChanges : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "NormalizedTagText",
                table: "Tag",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "NormalizedTagText",
                table: "Tag");
        }
    }
}
