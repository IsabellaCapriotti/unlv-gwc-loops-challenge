using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LoopsChallenge.Data.Migrations
{
    public partial class ChangesToTagNormalization : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Tag",
                table: "Tag");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "Tag");

            migrationBuilder.RenameColumn(
                name: "TagText",
                table: "Tag",
                newName: "DisplayTagText");

            migrationBuilder.AddColumn<bool>(
                name: "IsDefaultSuggested",
                table: "Tag",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AlterColumn<bool>(
                name: "HispanicLatino",
                table: "ProfileDetails",
                type: "bit",
                nullable: false,
                defaultValue: false,
                oldClrType: typeof(bool),
                oldType: "bit",
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Tag",
                table: "Tag",
                column: "NormalizedTagText");

            migrationBuilder.InsertData(
                table: "Tag",
                columns: new[] { "NormalizedTagText", "DisplayTagText", "IsDefaultSuggested" },
                values: new object[,]
                {
                    { "asian", "Asian", true },
                    { "autism", "Autism", true },
                    { "black", "Black", true },
                    { "disability", "Disability", true },
                    { "latinx", "Latinx", true },
                    { "lgbtq+", "LGBTQ+", true },
                    { "nonbinary", "Nonbinary", true },
                    { "poc", "POC", true },
                    { "transgender", "Transgender", true },
                    { "woman", "Woman", true }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Tag",
                table: "Tag");

            migrationBuilder.DeleteData(
                table: "Tag",
                keyColumn: "NormalizedTagText",
                keyValue: "asian");

            migrationBuilder.DeleteData(
                table: "Tag",
                keyColumn: "NormalizedTagText",
                keyValue: "autism");

            migrationBuilder.DeleteData(
                table: "Tag",
                keyColumn: "NormalizedTagText",
                keyValue: "black");

            migrationBuilder.DeleteData(
                table: "Tag",
                keyColumn: "NormalizedTagText",
                keyValue: "disability");

            migrationBuilder.DeleteData(
                table: "Tag",
                keyColumn: "NormalizedTagText",
                keyValue: "latinx");

            migrationBuilder.DeleteData(
                table: "Tag",
                keyColumn: "NormalizedTagText",
                keyValue: "lgbtq+");

            migrationBuilder.DeleteData(
                table: "Tag",
                keyColumn: "NormalizedTagText",
                keyValue: "nonbinary");

            migrationBuilder.DeleteData(
                table: "Tag",
                keyColumn: "NormalizedTagText",
                keyValue: "poc");

            migrationBuilder.DeleteData(
                table: "Tag",
                keyColumn: "NormalizedTagText",
                keyValue: "transgender");

            migrationBuilder.DeleteData(
                table: "Tag",
                keyColumn: "NormalizedTagText",
                keyValue: "woman");

            migrationBuilder.DropColumn(
                name: "IsDefaultSuggested",
                table: "Tag");

            migrationBuilder.RenameColumn(
                name: "DisplayTagText",
                table: "Tag",
                newName: "TagText");

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "Tag",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AlterColumn<bool>(
                name: "HispanicLatino",
                table: "ProfileDetails",
                type: "bit",
                nullable: true,
                oldClrType: typeof(bool),
                oldType: "bit");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Tag",
                table: "Tag",
                column: "Id");
        }
    }
}
