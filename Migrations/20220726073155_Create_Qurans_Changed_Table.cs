using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace surah_sender.Migrations
{
    public partial class Create_Qurans_Changed_Table : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "IdOfMessage",
                table: "Qurans",
                newName: "MessageId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "MessageId",
                table: "Qurans",
                newName: "IdOfMessage");
        }
    }
}
