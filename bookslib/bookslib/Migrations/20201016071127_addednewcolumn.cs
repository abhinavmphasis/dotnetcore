using Microsoft.EntityFrameworkCore.Migrations;

namespace bookslib.Migrations
{
    public partial class addednewcolumn : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "coverImageUrl",
                table: "Books",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "coverImageUrl",
                table: "Books");
        }
    }
}
