using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ProjecteMVVMWPFNou.Migrations
{
    public partial class InitialCreate : Migration
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
                    DniId = table.Column<Guid>(nullable: true),
                    Subject_Name = table.Column<string>(nullable: true),
                    Subject_Guid = table.Column<Guid>(nullable: true),
                    StudentBySubjectId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Entity", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Entity_Entity_DniId",
                        column: x => x.DniId,
                        principalTable: "Entity",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Entity_Entity_StudentBySubjectId",
                        column: x => x.StudentBySubjectId,
                        principalTable: "Entity",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Entity_DniId",
                table: "Entity",
                column: "DniId");

            migrationBuilder.CreateIndex(
                name: "IX_Entity_StudentBySubjectId",
                table: "Entity",
                column: "StudentBySubjectId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Entity");
        }
    }
}
