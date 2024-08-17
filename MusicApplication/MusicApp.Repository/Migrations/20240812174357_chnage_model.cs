using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MusicApp.Repository.Migrations
{
    /// <inheritdoc />
    public partial class chnage_model : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<double>(
                name: "Price",
                table: "Tracks",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<int>(
                name: "Quantity",
                table: "TrackInPlaylists",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Price",
                table: "Tracks");

            migrationBuilder.DropColumn(
                name: "Quantity",
                table: "TrackInPlaylists");
        }
    }
}
