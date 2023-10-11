using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataLogic.Migrations
{
    /// <inheritdoc />
    public partial class AddedNullSafety : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_People_JobPositions_PositionId",
                table: "People");

            migrationBuilder.RenameColumn(
                name: "PostionName",
                table: "JobPositions",
                newName: "PositionName");

            migrationBuilder.AlterColumn<int>(
                name: "PositionId",
                table: "People",
                type: "INTEGER",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "INTEGER");

            migrationBuilder.AddForeignKey(
                name: "FK_People_JobPositions_PositionId",
                table: "People",
                column: "PositionId",
                principalTable: "JobPositions",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_People_JobPositions_PositionId",
                table: "People");

            migrationBuilder.RenameColumn(
                name: "PositionName",
                table: "JobPositions",
                newName: "PostionName");

            migrationBuilder.AlterColumn<int>(
                name: "PositionId",
                table: "People",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "INTEGER",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_People_JobPositions_PositionId",
                table: "People",
                column: "PositionId",
                principalTable: "JobPositions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
