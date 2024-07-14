using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MikesKitchen.Common.DataContext.SqlServer.Migrations
{
    /// <inheritdoc />
    public partial class RemoveRecipeIngredientsFromUnitTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RecipeIngredients_UnitId",
                table: "RecipeIngredients");

            migrationBuilder.AddForeignKey(
                name: "FK_RecipeIngredients_Units_UnitID",
                table: "RecipeIngredients",
                column: "UnitID",
                principalTable: "Units",
                principalColumn: "UnitID",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RecipeIngredients_Units_UnitID",
                table: "RecipeIngredients");

            migrationBuilder.AddForeignKey(
                name: "FK_RecipeIngredients_UnitId",
                table: "RecipeIngredients",
                column: "UnitID",
                principalTable: "Units",
                principalColumn: "UnitID");
        }
    }
}
