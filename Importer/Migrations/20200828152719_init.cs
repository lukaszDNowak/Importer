using Microsoft.EntityFrameworkCore.Migrations;

namespace Importer.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "modules",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Number = table.Column<int>(nullable: false),
                    Code = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_modules", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "additionStdScores",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Module = table.Column<string>(nullable: true),
                    Section = table.Column<string>(nullable: true),
                    Score = table.Column<int>(nullable: false),
                    StdS06 = table.Column<int>(nullable: false),
                    StdS07 = table.Column<int>(nullable: false),
                    StdS08 = table.Column<int>(nullable: false),
                    StdS09 = table.Column<int>(nullable: false),
                    StdS10 = table.Column<int>(nullable: false),
                    StdS11 = table.Column<int>(nullable: false),
                    StdS12 = table.Column<int>(nullable: false),
                    StdS13 = table.Column<int>(nullable: false),
                    StdS14 = table.Column<int>(nullable: false),
                    StdS15 = table.Column<int>(nullable: false),
                    StdS16 = table.Column<int>(nullable: false),
                    StdS17 = table.Column<int>(nullable: false),
                    StdS18 = table.Column<int>(nullable: false),
                    StdS19 = table.Column<int>(nullable: false),
                    StdS20 = table.Column<int>(nullable: false),
                    Code = table.Column<string>(nullable: true),
                    ModuleId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_additionStdScores", x => x.Id);
                    table.ForeignKey(
                        name: "FK_additionStdScores_modules_ModuleId",
                        column: x => x.ModuleId,
                        principalTable: "modules",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "moduleErrorLookups",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Module = table.Column<string>(nullable: true),
                    Section = table.Column<string>(nullable: true),
                    Qnum = table.Column<string>(nullable: true),
                    Target = table.Column<string>(nullable: true),
                    Actual = table.Column<string>(nullable: true),
                    Category = table.Column<string>(nullable: true),
                    Comment = table.Column<string>(nullable: true),
                    Code = table.Column<string>(nullable: true),
                    ModuleId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_moduleErrorLookups", x => x.Id);
                    table.ForeignKey(
                        name: "FK_moduleErrorLookups_modules_ModuleId",
                        column: x => x.ModuleId,
                        principalTable: "modules",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "moduleLookups",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StandardScore = table.Column<int>(nullable: false),
                    Band = table.Column<int>(nullable: false),
                    Summary = table.Column<string>(nullable: true),
                    SkillLevel = table.Column<string>(nullable: true),
                    Code = table.Column<string>(nullable: true),
                    ModuleId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_moduleLookups", x => x.Id);
                    table.ForeignKey(
                        name: "FK_moduleLookups_modules_ModuleId",
                        column: x => x.ModuleId,
                        principalTable: "modules",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "multiplicationStdScores",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Module = table.Column<string>(nullable: true),
                    Section = table.Column<string>(nullable: true),
                    Score = table.Column<int>(nullable: false),
                    StdS06 = table.Column<int>(nullable: false),
                    StdS07 = table.Column<int>(nullable: false),
                    StdS08 = table.Column<int>(nullable: false),
                    StdS09 = table.Column<int>(nullable: false),
                    StdS10 = table.Column<int>(nullable: false),
                    StdS11 = table.Column<int>(nullable: false),
                    StdS12 = table.Column<int>(nullable: false),
                    StdS13 = table.Column<int>(nullable: false),
                    StdS14 = table.Column<int>(nullable: false),
                    StdS15 = table.Column<int>(nullable: false),
                    StdS16 = table.Column<int>(nullable: false),
                    StdS17 = table.Column<int>(nullable: false),
                    StdS18 = table.Column<int>(nullable: false),
                    StdS19 = table.Column<int>(nullable: false),
                    StdS20 = table.Column<int>(nullable: false),
                    Code = table.Column<string>(nullable: true),
                    ModuleId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_multiplicationStdScores", x => x.Id);
                    table.ForeignKey(
                        name: "FK_multiplicationStdScores_modules_ModuleId",
                        column: x => x.ModuleId,
                        principalTable: "modules",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "questions",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Module = table.Column<string>(nullable: true),
                    Type = table.Column<string>(nullable: true),
                    Type2 = table.Column<string>(nullable: true),
                    Section = table.Column<string>(nullable: true),
                    Qnum = table.Column<string>(nullable: true),
                    Content = table.Column<string>(nullable: true),
                    Response01 = table.Column<int>(nullable: false),
                    Response02 = table.Column<int>(nullable: false),
                    Response03 = table.Column<int>(nullable: false),
                    Response04 = table.Column<int>(nullable: false),
                    CorrectAnswer = table.Column<int>(nullable: false),
                    Code = table.Column<string>(nullable: true),
                    ModuleId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_questions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_questions_modules_ModuleId",
                        column: x => x.ModuleId,
                        principalTable: "modules",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "settings",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ModuleNumber = table.Column<int>(nullable: false),
                    Language = table.Column<string>(nullable: true),
                    Type = table.Column<string>(nullable: true),
                    Timer = table.Column<int>(nullable: false),
                    CountdownTimer = table.Column<string>(nullable: true),
                    FinishAfterCorrectInRow = table.Column<string>(nullable: true),
                    FinishAfterIncorrectInRow = table.Column<string>(nullable: true),
                    FinishAfterCorrectTotal = table.Column<string>(nullable: true),
                    FinishAfterIncorrectTotal = table.Column<string>(nullable: true),
                    MarkAsProbablyGuessAfterXIncorrectAnswersInRow = table.Column<string>(nullable: true),
                    MarkAsProbablyGuessAfterXIncorrectAnswersAditional = table.Column<string>(nullable: true),
                    MarkAsProbablyGuessAfterXIncorrectAnswersMultiplication = table.Column<string>(nullable: true),
                    Calculator = table.Column<string>(nullable: true),
                    ReportSummary = table.Column<string>(nullable: true),
                    ReportSections = table.Column<string>(nullable: true),
                    ReportFull = table.Column<string>(nullable: true),
                    Code = table.Column<string>(nullable: true),
                    ModuleId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_settings", x => x.id);
                    table.ForeignKey(
                        name: "FK_settings_modules_ModuleId",
                        column: x => x.ModuleId,
                        principalTable: "modules",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_additionStdScores_ModuleId",
                table: "additionStdScores",
                column: "ModuleId");

            migrationBuilder.CreateIndex(
                name: "IX_moduleErrorLookups_ModuleId",
                table: "moduleErrorLookups",
                column: "ModuleId");

            migrationBuilder.CreateIndex(
                name: "IX_moduleLookups_ModuleId",
                table: "moduleLookups",
                column: "ModuleId");

            migrationBuilder.CreateIndex(
                name: "IX_multiplicationStdScores_ModuleId",
                table: "multiplicationStdScores",
                column: "ModuleId");

            migrationBuilder.CreateIndex(
                name: "IX_questions_ModuleId",
                table: "questions",
                column: "ModuleId");

            migrationBuilder.CreateIndex(
                name: "IX_settings_ModuleId",
                table: "settings",
                column: "ModuleId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "additionStdScores");

            migrationBuilder.DropTable(
                name: "moduleErrorLookups");

            migrationBuilder.DropTable(
                name: "moduleLookups");

            migrationBuilder.DropTable(
                name: "multiplicationStdScores");

            migrationBuilder.DropTable(
                name: "questions");

            migrationBuilder.DropTable(
                name: "settings");

            migrationBuilder.DropTable(
                name: "modules");
        }
    }
}
