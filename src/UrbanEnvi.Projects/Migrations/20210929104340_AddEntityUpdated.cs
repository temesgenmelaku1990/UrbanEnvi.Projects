using Microsoft.EntityFrameworkCore.Migrations;
using NodaTime;

#nullable disable

namespace UrbanEnvi.Migrations
{
    public partial class AddEntityUpdated : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Instant>(
                name: "Updated",
                schema: "Projects",
                table: "Projects",
                type: "timestamp with time zone",
                nullable: true);

            migrationBuilder.AddColumn<Instant>(
                name: "Updated",
                schema: "Projects",
                table: "ProjectCategories",
                type: "timestamp with time zone",
                nullable: true);

            migrationBuilder.AddColumn<Instant>(
                name: "Updated",
                schema: "Projects",
                table: "AssessmentTypes",
                type: "timestamp with time zone",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Updated",
                schema: "Projects",
                table: "Projects");

            migrationBuilder.DropColumn(
                name: "Updated",
                schema: "Projects",
                table: "ProjectCategories");

            migrationBuilder.DropColumn(
                name: "Updated",
                schema: "Projects",
                table: "AssessmentTypes");
        }
    }
}
