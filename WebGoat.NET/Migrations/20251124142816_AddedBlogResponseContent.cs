using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebGoat.NET.Migrations
{
    /// <inheritdoc />
    public partial class AddedBlogResponseContent : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Contents",
                table: "BlogResponses",
                type: "TEXT",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "TEXT");

            migrationBuilder.CreateTable(
                name: "BlogResponseContents",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Content = table.Column<string>(type: "TEXT", nullable: false),
                    BlogResponseId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BlogResponseContents", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BlogResponseContents_BlogResponses_BlogResponseId",
                        column: x => x.BlogResponseId,
                        principalTable: "BlogResponses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BlogResponseContents_BlogResponseId",
                table: "BlogResponseContents",
                column: "BlogResponseId",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BlogResponseContents");

            migrationBuilder.AlterColumn<string>(
                name: "Contents",
                table: "BlogResponses",
                type: "TEXT",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldNullable: true);
        }
    }
}
