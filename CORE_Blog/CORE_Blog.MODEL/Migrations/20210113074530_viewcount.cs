using Microsoft.EntityFrameworkCore.Migrations;

namespace CORE_Blog.MODEL.Migrations
{
    public partial class viewcount : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "ViewCount",
                table: "Posts",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "ViewCount",
                table: "Posts",
                nullable: true,
                oldClrType: typeof(int));
        }
    }
}
