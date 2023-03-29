using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EntityFramework.Migrations
{
    /// <inheritdoc />
    public partial class Updated01 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ObjectCollections",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    DisplayName = table.Column<string>(type: "TEXT", nullable: true),
                    Description = table.Column<string>(type: "TEXT", nullable: true),
                    CreationDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Comments = table.Column<string>(type: "TEXT", nullable: true),
                    Icon = table.Column<string>(type: "TEXT", nullable: true),
                    ParentObjectCollectionId = table.Column<Guid>(type: "TEXT", nullable: true),
                    ParentProjectId = table.Column<Guid>(type: "TEXT", nullable: true),
                    ParentTaskId = table.Column<Guid>(type: "TEXT", nullable: true),
                    ParentSessionId = table.Column<Guid>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ObjectCollections", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ObjectCollections_ObjectCollections_ParentObjectCollectionId",
                        column: x => x.ParentObjectCollectionId,
                        principalTable: "ObjectCollections",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Projects",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    ProjectName = table.Column<string>(type: "TEXT", nullable: true),
                    DisplayName = table.Column<string>(type: "TEXT", nullable: true),
                    Description = table.Column<string>(type: "TEXT", nullable: true),
                    CreationDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Comments = table.Column<string>(type: "TEXT", nullable: true),
                    Icon = table.Column<string>(type: "TEXT", nullable: true),
                    ParentObjectCollectionId = table.Column<Guid>(type: "TEXT", nullable: true),
                    ParentProjectId = table.Column<Guid>(type: "TEXT", nullable: true),
                    ParentTaskId = table.Column<Guid>(type: "TEXT", nullable: true),
                    ParentSessionId = table.Column<Guid>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Projects", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Projects_ObjectCollections_ParentObjectCollectionId",
                        column: x => x.ParentObjectCollectionId,
                        principalTable: "ObjectCollections",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Projects_Projects_ParentProjectId",
                        column: x => x.ParentProjectId,
                        principalTable: "Projects",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Sessions",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    SessionName = table.Column<string>(type: "TEXT", nullable: true),
                    DisplayName = table.Column<string>(type: "TEXT", nullable: true),
                    Description = table.Column<string>(type: "TEXT", nullable: true),
                    CreationDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Comments = table.Column<string>(type: "TEXT", nullable: true),
                    Icon = table.Column<string>(type: "TEXT", nullable: true),
                    ParentObjectCollectionId = table.Column<Guid>(type: "TEXT", nullable: true),
                    ParentProjectId = table.Column<Guid>(type: "TEXT", nullable: true),
                    ParentTaskId = table.Column<Guid>(type: "TEXT", nullable: true),
                    ParentSessionId = table.Column<Guid>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sessions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Sessions_ObjectCollections_ParentObjectCollectionId",
                        column: x => x.ParentObjectCollectionId,
                        principalTable: "ObjectCollections",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Sessions_Projects_ParentProjectId",
                        column: x => x.ParentProjectId,
                        principalTable: "Projects",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Sessions_Sessions_ParentSessionId",
                        column: x => x.ParentSessionId,
                        principalTable: "Sessions",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Tasks",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    TaskName = table.Column<string>(type: "TEXT", nullable: true),
                    DisplayName = table.Column<string>(type: "TEXT", nullable: true),
                    Description = table.Column<string>(type: "TEXT", nullable: true),
                    CreationDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Comments = table.Column<string>(type: "TEXT", nullable: true),
                    Icon = table.Column<string>(type: "TEXT", nullable: true),
                    ParentObjectCollectionId = table.Column<Guid>(type: "TEXT", nullable: true),
                    ParentProjectId = table.Column<Guid>(type: "TEXT", nullable: true),
                    ParentTaskId = table.Column<Guid>(type: "TEXT", nullable: true),
                    ParentSessionId = table.Column<Guid>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tasks", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Tasks_ObjectCollections_ParentObjectCollectionId",
                        column: x => x.ParentObjectCollectionId,
                        principalTable: "ObjectCollections",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Tasks_Projects_ParentProjectId",
                        column: x => x.ParentProjectId,
                        principalTable: "Projects",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Tasks_Sessions_ParentSessionId",
                        column: x => x.ParentSessionId,
                        principalTable: "Sessions",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Tasks_Tasks_ParentTaskId",
                        column: x => x.ParentTaskId,
                        principalTable: "Tasks",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_ObjectCollections_ParentObjectCollectionId",
                table: "ObjectCollections",
                column: "ParentObjectCollectionId");

            migrationBuilder.CreateIndex(
                name: "IX_ObjectCollections_ParentProjectId",
                table: "ObjectCollections",
                column: "ParentProjectId");

            migrationBuilder.CreateIndex(
                name: "IX_ObjectCollections_ParentSessionId",
                table: "ObjectCollections",
                column: "ParentSessionId");

            migrationBuilder.CreateIndex(
                name: "IX_ObjectCollections_ParentTaskId",
                table: "ObjectCollections",
                column: "ParentTaskId");

            migrationBuilder.CreateIndex(
                name: "IX_Projects_ParentObjectCollectionId",
                table: "Projects",
                column: "ParentObjectCollectionId");

            migrationBuilder.CreateIndex(
                name: "IX_Projects_ParentProjectId",
                table: "Projects",
                column: "ParentProjectId");

            migrationBuilder.CreateIndex(
                name: "IX_Projects_ParentSessionId",
                table: "Projects",
                column: "ParentSessionId");

            migrationBuilder.CreateIndex(
                name: "IX_Projects_ParentTaskId",
                table: "Projects",
                column: "ParentTaskId");

            migrationBuilder.CreateIndex(
                name: "IX_Sessions_ParentObjectCollectionId",
                table: "Sessions",
                column: "ParentObjectCollectionId");

            migrationBuilder.CreateIndex(
                name: "IX_Sessions_ParentProjectId",
                table: "Sessions",
                column: "ParentProjectId");

            migrationBuilder.CreateIndex(
                name: "IX_Sessions_ParentSessionId",
                table: "Sessions",
                column: "ParentSessionId");

            migrationBuilder.CreateIndex(
                name: "IX_Sessions_ParentTaskId",
                table: "Sessions",
                column: "ParentTaskId");

            migrationBuilder.CreateIndex(
                name: "IX_Tasks_ParentObjectCollectionId",
                table: "Tasks",
                column: "ParentObjectCollectionId");

            migrationBuilder.CreateIndex(
                name: "IX_Tasks_ParentProjectId",
                table: "Tasks",
                column: "ParentProjectId");

            migrationBuilder.CreateIndex(
                name: "IX_Tasks_ParentSessionId",
                table: "Tasks",
                column: "ParentSessionId");

            migrationBuilder.CreateIndex(
                name: "IX_Tasks_ParentTaskId",
                table: "Tasks",
                column: "ParentTaskId");

            migrationBuilder.AddForeignKey(
                name: "FK_ObjectCollections_Projects_ParentProjectId",
                table: "ObjectCollections",
                column: "ParentProjectId",
                principalTable: "Projects",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ObjectCollections_Sessions_ParentSessionId",
                table: "ObjectCollections",
                column: "ParentSessionId",
                principalTable: "Sessions",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ObjectCollections_Tasks_ParentTaskId",
                table: "ObjectCollections",
                column: "ParentTaskId",
                principalTable: "Tasks",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Projects_Sessions_ParentSessionId",
                table: "Projects",
                column: "ParentSessionId",
                principalTable: "Sessions",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Projects_Tasks_ParentTaskId",
                table: "Projects",
                column: "ParentTaskId",
                principalTable: "Tasks",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Sessions_Tasks_ParentTaskId",
                table: "Sessions",
                column: "ParentTaskId",
                principalTable: "Tasks",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ObjectCollections_Projects_ParentProjectId",
                table: "ObjectCollections");

            migrationBuilder.DropForeignKey(
                name: "FK_Sessions_Projects_ParentProjectId",
                table: "Sessions");

            migrationBuilder.DropForeignKey(
                name: "FK_Tasks_Projects_ParentProjectId",
                table: "Tasks");

            migrationBuilder.DropForeignKey(
                name: "FK_ObjectCollections_Sessions_ParentSessionId",
                table: "ObjectCollections");

            migrationBuilder.DropForeignKey(
                name: "FK_Tasks_Sessions_ParentSessionId",
                table: "Tasks");

            migrationBuilder.DropForeignKey(
                name: "FK_ObjectCollections_Tasks_ParentTaskId",
                table: "ObjectCollections");

            migrationBuilder.DropTable(
                name: "Projects");

            migrationBuilder.DropTable(
                name: "Sessions");

            migrationBuilder.DropTable(
                name: "Tasks");

            migrationBuilder.DropTable(
                name: "ObjectCollections");
        }
    }
}
