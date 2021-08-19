using Microsoft.EntityFrameworkCore.Migrations;

namespace PersonnelMgtBackend.Migrations
{
    public partial class AddPersonAgainToDb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "People",
                columns: new[] { "Id", "FirstName", "LastName", "Rank" },
                values: new object[] { -1, "Tim", "Walker", "Corporal" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "People",
                keyColumn: "Id",
                keyValue: -1);
        }
    }
}
