using Microsoft.EntityFrameworkCore.Migrations;
using System;

namespace SimpleDataAccess.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Tweets",
                columns: table => new
                {
                    TwitterId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    AuthorId = table.Column<int>(type: "INTEGER", nullable: false),
                    Text = table.Column<string>(type: "TEXT", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tweets", x => x.TwitterId);
                });

            migrationBuilder.CreateTable(
                name: "Hashtags",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Text = table.Column<string>(type: "TEXT", nullable: true),
                    TweetId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Hashtags", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Hashtags_Tweets_TweetId",
                        column: x => x.TweetId,
                        principalTable: "Tweets",
                        principalColumn: "TwitterId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Tweets",
                columns: new[] { "TwitterId", "AuthorId", "CreatedAt", "Text" },
                values: new object[] { 1, 100, new DateTime(2022, 8, 20, 4, 30, 43, 338, DateTimeKind.Utc).AddTicks(4783), "Haha!" });

            migrationBuilder.InsertData(
                table: "Tweets",
                columns: new[] { "TwitterId", "AuthorId", "CreatedAt", "Text" },
                values: new object[] { 2, 101, new DateTime(2022, 8, 20, 4, 30, 43, 338, DateTimeKind.Utc).AddTicks(5219), "Boo!" });

            migrationBuilder.CreateIndex(
                name: "IX_Hashtags_TweetId",
                table: "Hashtags",
                column: "TweetId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Hashtags");

            migrationBuilder.DropTable(
                name: "Tweets");
        }
    }
}