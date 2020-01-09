using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ProjecteMVVMWPFNou.Migrations
{
    public partial class initialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Entity",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Discriminator = table.Column<string>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Dni = table.Column<string>(nullable: true),
                    ChairNumber = table.Column<int>(nullable: true),
                    Guid = table.Column<Guid>(nullable: true),
                    StudentId = table.Column<Guid>(nullable: true),
                    SubjectId = table.Column<Guid>(nullable: true),
                    Subject_Name = table.Column<string>(nullable: true),
                    Subject_Guid = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Entity", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Entity_Entity_StudentId",
                        column: x => x.StudentId,
                        principalTable: "Entity",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Entity_Entity_SubjectId",
                        column: x => x.SubjectId,
                        principalTable: "Entity",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Entity_StudentId",
                table: "Entity",
                column: "StudentId");

            migrationBuilder.CreateIndex(
                name: "IX_Entity_SubjectId",
                table: "Entity",
                column: "SubjectId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Entity");
        }
    }
}
