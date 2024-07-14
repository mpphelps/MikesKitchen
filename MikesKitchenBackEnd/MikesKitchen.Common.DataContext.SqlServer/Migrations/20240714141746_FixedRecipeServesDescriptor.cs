using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MikesKitchen.Common.DataContext.SqlServer.Migrations
{
    /// <inheritdoc />
    public partial class FixedRecipeServesDescriptor : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ServesID",
                table: "Recipes");

            migrationBuilder.AddForeignKey(
                name: "FK_Recipes_ServesDescriptors_ServesDescriptorId",
                table: "Recipes",
                column: "ServesDescriptorId",
                principalTable: "ServesDescriptors",
                principalColumn: "ServesDescriptorId",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Recipes_ServesDescriptors_ServesDescriptorId",
                table: "Recipes");

            migrationBuilder.AddForeignKey(
                name: "FK_ServesID",
                table: "Recipes",
                column: "ServesDescriptorId",
                principalTable: "ServesDescriptors",
                principalColumn: "ServesDescriptorId");
        }
    }
}
