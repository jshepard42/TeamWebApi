using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TeamWebAPI.Migrations
{
    /// <inheritdoc />
    public partial class addField : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "DifficultyLevel",
                table: "Hobbies",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DifficultyLevel",
                table: "Hobbies");
        }
    }
}
