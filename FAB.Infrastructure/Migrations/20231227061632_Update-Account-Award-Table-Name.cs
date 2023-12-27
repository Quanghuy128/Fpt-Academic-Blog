using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FAB.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class UpdateAccountAwardTableName : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AccountAward_account_AccountsId",
                schema: "fab",
                table: "AccountAward");

            migrationBuilder.DropForeignKey(
                name: "FK_AccountAward_award_AwardsId",
                schema: "fab",
                table: "AccountAward");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AccountAward",
                schema: "fab",
                table: "AccountAward");

            migrationBuilder.RenameTable(
                name: "AccountAward",
                schema: "fab",
                newName: "account_award",
                newSchema: "fab");

            migrationBuilder.RenameIndex(
                name: "IX_AccountAward_AwardsId",
                schema: "fab",
                table: "account_award",
                newName: "IX_account_award_AwardsId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_account_award",
                schema: "fab",
                table: "account_award",
                columns: new[] { "AccountsId", "AwardsId" });

            migrationBuilder.AddForeignKey(
                name: "FK_account_award_account_AccountsId",
                schema: "fab",
                table: "account_award",
                column: "AccountsId",
                principalSchema: "fab",
                principalTable: "account",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_account_award_award_AwardsId",
                schema: "fab",
                table: "account_award",
                column: "AwardsId",
                principalSchema: "fab",
                principalTable: "award",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_account_award_account_AccountsId",
                schema: "fab",
                table: "account_award");

            migrationBuilder.DropForeignKey(
                name: "FK_account_award_award_AwardsId",
                schema: "fab",
                table: "account_award");

            migrationBuilder.DropPrimaryKey(
                name: "PK_account_award",
                schema: "fab",
                table: "account_award");

            migrationBuilder.RenameTable(
                name: "account_award",
                schema: "fab",
                newName: "AccountAward",
                newSchema: "fab");

            migrationBuilder.RenameIndex(
                name: "IX_account_award_AwardsId",
                schema: "fab",
                table: "AccountAward",
                newName: "IX_AccountAward_AwardsId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_AccountAward",
                schema: "fab",
                table: "AccountAward",
                columns: new[] { "AccountsId", "AwardsId" });

            migrationBuilder.AddForeignKey(
                name: "FK_AccountAward_account_AccountsId",
                schema: "fab",
                table: "AccountAward",
                column: "AccountsId",
                principalSchema: "fab",
                principalTable: "account",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AccountAward_award_AwardsId",
                schema: "fab",
                table: "AccountAward",
                column: "AwardsId",
                principalSchema: "fab",
                principalTable: "award",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
