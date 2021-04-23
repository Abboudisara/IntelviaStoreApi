using Microsoft.EntityFrameworkCore.Migrations;

namespace TestAspCore.Migrations
{
    public partial class catModelUpdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ImageNam",
                table: "Categories",
                newName: "ImageName");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ImageName",
                table: "Categories",
                newName: "ImageNam");
        }
    }
}
