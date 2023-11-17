using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TestForCourse_Bokalo.Migrations
{
    public partial class ChangeDBForNUll : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Catalogs_Catalogs_ParentId",
                table: "Catalogs");

            migrationBuilder.AlterColumn<int>(
                name: "ParentId",
                table: "Catalogs",
                type: "INTEGER",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "INTEGER");

            migrationBuilder.AddForeignKey(
                name: "FK_Catalogs_Catalogs_ParentId",
                table: "Catalogs",
                column: "ParentId",
                principalTable: "Catalogs",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Catalogs_Catalogs_ParentId",
                table: "Catalogs");

            migrationBuilder.AlterColumn<int>(
                name: "ParentId",
                table: "Catalogs",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "INTEGER",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Catalogs_Catalogs_ParentId",
                table: "Catalogs",
                column: "ParentId",
                principalTable: "Catalogs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
