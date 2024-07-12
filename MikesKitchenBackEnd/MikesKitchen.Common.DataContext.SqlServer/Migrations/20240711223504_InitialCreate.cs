using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MikesKitchen.Common.DataContext.SqlServer.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "RecipeUser",
                columns: table => new
                {
                    RecipeId = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RecipeUser", x => new { x.RecipeId, x.UserId });
                });

            migrationBuilder.CreateTable(
                name: "ServesDescriptors",
                columns: table => new
                {
                    ServesDescriptorId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ServesDescriptor = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__ServesDe__F4B29F657004D445", x => x.ServesDescriptorId);
                });

            migrationBuilder.CreateTable(
                name: "Units",
                columns: table => new
                {
                    UnitID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UnitDescriptor = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Units", x => x.UnitID);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Password = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.UserId);
                });

            migrationBuilder.CreateTable(
                name: "Recipes",
                columns: table => new
                {
                    RecipeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    ServesDescriptorId = table.Column<int>(type: "int", nullable: false),
                    ServesQuantity = table.Column<int>(type: "int", nullable: false),
                    PrepTime = table.Column<int>(type: "int", nullable: false),
                    CookTime = table.Column<int>(type: "int", nullable: false),
                    Photo = table.Column<byte[]>(type: "image", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Recipes__FDD988B08DADB37A", x => x.RecipeId);
                    table.ForeignKey(
                        name: "FK_ServesID",
                        column: x => x.ServesDescriptorId,
                        principalTable: "ServesDescriptors",
                        principalColumn: "ServesDescriptorId");
                    table.ForeignKey(
                        name: "FK_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "UserId");
                });

            migrationBuilder.CreateTable(
                name: "Favorites",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "int", nullable: false),
                    RecipeId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RecipeFavorites", x => new { x.UserId, x.RecipeId });
                    table.ForeignKey(
                        name: "FK_RecipeFavorites_RecipeId",
                        column: x => x.RecipeId,
                        principalTable: "Recipes",
                        principalColumn: "RecipeId");
                    table.ForeignKey(
                        name: "FK_RecipeFavorites_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "UserId");
                });

            migrationBuilder.CreateTable(
                name: "RecipeIngredients",
                columns: table => new
                {
                    RecipeId = table.Column<int>(type: "int", nullable: false),
                    IngredientId = table.Column<int>(type: "int", nullable: false),
                    Ingredient = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Quantity = table.Column<double>(type: "float", nullable: false),
                    UnitID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RecipeIngredient", x => new { x.RecipeId, x.IngredientId });
                    table.ForeignKey(
                        name: "FK_RecipeIngredients_RecipeId",
                        column: x => x.RecipeId,
                        principalTable: "Recipes",
                        principalColumn: "RecipeId");
                    table.ForeignKey(
                        name: "FK_RecipeIngredients_UnitId",
                        column: x => x.UnitID,
                        principalTable: "Units",
                        principalColumn: "UnitID");
                });

            migrationBuilder.CreateTable(
                name: "RecipeSteps",
                columns: table => new
                {
                    RecipeId = table.Column<int>(type: "int", nullable: false),
                    StepId = table.Column<int>(type: "int", nullable: false),
                    Step = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    Photo = table.Column<byte[]>(type: "image", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RecipeStep", x => new { x.RecipeId, x.StepId });
                    table.ForeignKey(
                        name: "FK_RecipeSteps_RecipeId",
                        column: x => x.RecipeId,
                        principalTable: "Recipes",
                        principalColumn: "RecipeId");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Favorites_RecipeId",
                table: "Favorites",
                column: "RecipeId");

            migrationBuilder.CreateIndex(
                name: "IX_RecipeIngredients_UnitID",
                table: "RecipeIngredients",
                column: "UnitID");

            migrationBuilder.CreateIndex(
                name: "IX_Recipes_ServesDescriptorId",
                table: "Recipes",
                column: "ServesDescriptorId");

            migrationBuilder.CreateIndex(
                name: "IX_Recipes_UserId",
                table: "Recipes",
                column: "UserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Favorites");

            migrationBuilder.DropTable(
                name: "RecipeIngredients");

            migrationBuilder.DropTable(
                name: "RecipeSteps");

            migrationBuilder.DropTable(
                name: "RecipeUser");

            migrationBuilder.DropTable(
                name: "Units");

            migrationBuilder.DropTable(
                name: "Recipes");

            migrationBuilder.DropTable(
                name: "ServesDescriptors");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
