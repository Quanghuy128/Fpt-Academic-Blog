using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FAB.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "fab");

            migrationBuilder.CreateTable(
                name: "award",
                schema: "fab",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    name = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    icon_url = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: false),
                    point = table.Column<int>(type: "integer", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    CreatedBy = table.Column<string>(type: "text", nullable: true),
                    UpdatedBy = table.Column<string>(type: "text", nullable: true),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_award", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "category",
                schema: "fab",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    name = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    status = table.Column<int>(type: "integer", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    CreatedBy = table.Column<string>(type: "text", nullable: true),
                    UpdatedBy = table.Column<string>(type: "text", nullable: true),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_category", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "field",
                schema: "fab",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    name = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    CreatedBy = table.Column<string>(type: "text", nullable: true),
                    UpdatedBy = table.Column<string>(type: "text", nullable: true),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_field", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "account",
                schema: "fab",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    gmail = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    first_name = table.Column<string>(type: "character varying(30)", maxLength: 30, nullable: false),
                    last_name = table.Column<string>(type: "character varying(30)", maxLength: 30, nullable: false),
                    blogs_number = table.Column<int>(type: "integer", nullable: false),
                    status = table.Column<int>(type: "integer", nullable: false),
                    field_id = table.Column<Guid>(type: "uuid", nullable: false),
                    Award = table.Column<Guid>(type: "uuid", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    CreatedBy = table.Column<string>(type: "text", nullable: true),
                    UpdatedBy = table.Column<string>(type: "text", nullable: true),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_account", x => x.Id);
                    table.ForeignKey(
                        name: "FK_account_field_field_id",
                        column: x => x.field_id,
                        principalSchema: "fab",
                        principalTable: "field",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                });

            migrationBuilder.CreateTable(
                name: "AccountAward",
                schema: "fab",
                columns: table => new
                {
                    AccountsId = table.Column<Guid>(type: "uuid", nullable: false),
                    AwardsId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AccountAward", x => new { x.AccountsId, x.AwardsId });
                    table.ForeignKey(
                        name: "FK_AccountAward_account_AccountsId",
                        column: x => x.AccountsId,
                        principalSchema: "fab",
                        principalTable: "account",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AccountAward_award_AwardsId",
                        column: x => x.AwardsId,
                        principalSchema: "fab",
                        principalTable: "award",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "banned_info",
                schema: "fab",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    account_id = table.Column<Guid>(type: "uuid", nullable: false),
                    message = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    CreatedBy = table.Column<string>(type: "text", nullable: true),
                    UpdatedBy = table.Column<string>(type: "text", nullable: true),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_banned_info", x => x.Id);
                    table.ForeignKey(
                        name: "FK_banned_info_account_account_id",
                        column: x => x.account_id,
                        principalSchema: "fab",
                        principalTable: "account",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                });

            migrationBuilder.CreateTable(
                name: "blog",
                schema: "fab",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    thumbnail_url = table.Column<string>(type: "character varying(1000)", maxLength: 1000, nullable: false),
                    title = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    content = table.Column<string>(type: "character varying(1000)", maxLength: 1000, nullable: false),
                    views = table.Column<int>(type: "integer", nullable: false),
                    status = table.Column<int>(type: "integer", nullable: false),
                    reviewer_id = table.Column<Guid>(type: "uuid", nullable: false),
                    author_id = table.Column<Guid>(type: "uuid", nullable: false),
                    category_id = table.Column<Guid>(type: "uuid", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    CreatedBy = table.Column<string>(type: "text", nullable: true),
                    UpdatedBy = table.Column<string>(type: "text", nullable: true),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_blog", x => x.Id);
                    table.ForeignKey(
                        name: "FK_blog_account_author_id",
                        column: x => x.author_id,
                        principalSchema: "fab",
                        principalTable: "account",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "FK_blog_account_reviewer_id",
                        column: x => x.reviewer_id,
                        principalSchema: "fab",
                        principalTable: "account",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "FK_blog_category_category_id",
                        column: x => x.category_id,
                        principalSchema: "fab",
                        principalTable: "category",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                });

            migrationBuilder.CreateTable(
                name: "notification",
                schema: "fab",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    message = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: false),
                    status = table.Column<int>(type: "integer", nullable: false),
                    type = table.Column<int>(type: "integer", nullable: false),
                    from_account_id = table.Column<Guid>(type: "uuid", nullable: false),
                    to_account_id = table.Column<Guid>(type: "uuid", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    CreatedBy = table.Column<string>(type: "text", nullable: true),
                    UpdatedBy = table.Column<string>(type: "text", nullable: true),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_notification", x => x.Id);
                    table.ForeignKey(
                        name: "FK_notification_account_from_account_id",
                        column: x => x.from_account_id,
                        principalSchema: "fab",
                        principalTable: "account",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "FK_notification_account_to_account_id",
                        column: x => x.to_account_id,
                        principalSchema: "fab",
                        principalTable: "account",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                });

            migrationBuilder.CreateTable(
                name: "comment",
                schema: "fab",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    content = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: false),
                    commentor_id = table.Column<Guid>(type: "uuid", nullable: false),
                    reply_to = table.Column<Guid>(type: "uuid", nullable: false),
                    BlogId = table.Column<Guid>(type: "uuid", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    CreatedBy = table.Column<string>(type: "text", nullable: true),
                    UpdatedBy = table.Column<string>(type: "text", nullable: true),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_comment", x => x.Id);
                    table.ForeignKey(
                        name: "FK_comment_account_commentor_id",
                        column: x => x.commentor_id,
                        principalSchema: "fab",
                        principalTable: "account",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "FK_comment_blog_BlogId",
                        column: x => x.BlogId,
                        principalSchema: "fab",
                        principalTable: "blog",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_comment_comment_reply_to",
                        column: x => x.reply_to,
                        principalSchema: "fab",
                        principalTable: "comment",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                });

            migrationBuilder.CreateIndex(
                name: "IX_account_field_id",
                schema: "fab",
                table: "account",
                column: "field_id");

            migrationBuilder.CreateIndex(
                name: "IX_AccountAward_AwardsId",
                schema: "fab",
                table: "AccountAward",
                column: "AwardsId");

            migrationBuilder.CreateIndex(
                name: "IX_banned_info_account_id",
                schema: "fab",
                table: "banned_info",
                column: "account_id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_blog_author_id",
                schema: "fab",
                table: "blog",
                column: "author_id");

            migrationBuilder.CreateIndex(
                name: "IX_blog_category_id",
                schema: "fab",
                table: "blog",
                column: "category_id");

            migrationBuilder.CreateIndex(
                name: "IX_blog_reviewer_id",
                schema: "fab",
                table: "blog",
                column: "reviewer_id");

            migrationBuilder.CreateIndex(
                name: "IX_comment_BlogId",
                schema: "fab",
                table: "comment",
                column: "BlogId");

            migrationBuilder.CreateIndex(
                name: "IX_comment_commentor_id",
                schema: "fab",
                table: "comment",
                column: "commentor_id");

            migrationBuilder.CreateIndex(
                name: "IX_comment_reply_to",
                schema: "fab",
                table: "comment",
                column: "reply_to",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_notification_from_account_id",
                schema: "fab",
                table: "notification",
                column: "from_account_id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_notification_to_account_id",
                schema: "fab",
                table: "notification",
                column: "to_account_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AccountAward",
                schema: "fab");

            migrationBuilder.DropTable(
                name: "banned_info",
                schema: "fab");

            migrationBuilder.DropTable(
                name: "comment",
                schema: "fab");

            migrationBuilder.DropTable(
                name: "notification",
                schema: "fab");

            migrationBuilder.DropTable(
                name: "award",
                schema: "fab");

            migrationBuilder.DropTable(
                name: "blog",
                schema: "fab");

            migrationBuilder.DropTable(
                name: "account",
                schema: "fab");

            migrationBuilder.DropTable(
                name: "category",
                schema: "fab");

            migrationBuilder.DropTable(
                name: "field",
                schema: "fab");
        }
    }
}
