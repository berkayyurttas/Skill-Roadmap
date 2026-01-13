using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SkillRoadmap.Migrations
{
    /// <inheritdoc />
    public partial class Added_UserProgress_Table : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "CreationTime",
                table: "AppRoadmapSteps",
                type: "timestamp without time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<Guid>(
                name: "CreatorId",
                table: "AppRoadmapSteps",
                type: "uuid",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "LastModificationTime",
                table: "AppRoadmapSteps",
                type: "timestamp without time zone",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "LastModifierId",
                table: "AppRoadmapSteps",
                type: "uuid",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "AppUserProgresses",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    UserId = table.Column<Guid>(type: "uuid", nullable: false),
                    RoadmapStepId = table.Column<Guid>(type: "uuid", nullable: false),
                    IsCompleted = table.Column<bool>(type: "boolean", nullable: false),
                    MentorNote = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: false),
                    CompletionDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    CreationTime = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    CreatorId = table.Column<Guid>(type: "uuid", nullable: true),
                    LastModificationTime = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    LastModifierId = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppUserProgresses", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AppUserProgresses");

            migrationBuilder.DropColumn(
                name: "CreationTime",
                table: "AppRoadmapSteps");

            migrationBuilder.DropColumn(
                name: "CreatorId",
                table: "AppRoadmapSteps");

            migrationBuilder.DropColumn(
                name: "LastModificationTime",
                table: "AppRoadmapSteps");

            migrationBuilder.DropColumn(
                name: "LastModifierId",
                table: "AppRoadmapSteps");
        }
    }
}
