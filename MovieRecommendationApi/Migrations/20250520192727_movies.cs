using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MovieRecommendationApi.Migrations
{
    /// <inheritdoc />
    public partial class movies : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "MovieUrl",
                table: "Movies",
                type: "longtext",
                nullable: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "MovieUrl",
                table: "Movies");
        }
    }
}
