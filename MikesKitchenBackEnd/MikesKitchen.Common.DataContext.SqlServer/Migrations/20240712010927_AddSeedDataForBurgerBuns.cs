using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace MikesKitchen.Common.DataContext.SqlServer.Migrations
{
    /// <inheritdoc />
    public partial class AddSeedDataForBurgerBuns : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "ServesDescriptors",
                columns: new[] { "ServesDescriptorId", "ServesDescriptor" },
                values: new object[,]
                {
                    { 1, "Yields" },
                    { 2, "Makes" }
                });

            migrationBuilder.InsertData(
                table: "Units",
                columns: new[] { "UnitID", "UnitDescriptor" },
                values: new object[,]
                {
                    { 1, "ea" },
                    { 2, "tsp" },
                    { 3, "tbsp" },
                    { 4, "cup" },
                    { 5, "pt" },
                    { 6, "qt" },
                    { 7, "gal" },
                    { 8, "oz" },
                    { 9, "g" },
                    { 10, "kg" },
                    { 11, "fl oz" },
                    { 12, "lbs" },
                    { 13, "ml" },
                    { 14, "l" }
                });

            migrationBuilder.InsertData(
                table: "Recipes",
                columns: new[] { "RecipeId", "CookTime", "Photo", "PrepTime", "ServesDescriptorId", "ServesQuantity", "Title", "UserId" },
                values: new object[] { 1, 15, null, 25, 1, 1, "Beautiful Burger Buns", 1 });

            migrationBuilder.InsertData(
                table: "RecipeIngredients",
                columns: new[] { "IngredientId", "RecipeId", "Ingredient", "Quantity", "UnitID" },
                values: new object[,]
                {
                    { 1, 1, "King Arthur Unbleached All-Purpose Flour", 420.0, 9 },
                    { 2, 1, "water, lukewarm", 227.0, 9 },
                    { 3, 1, "butter, at room temperature\r\n", 28.0, 9 },
                    { 4, 1, "large egg", 1.0, 1 },
                    { 5, 1, "granulated sugar", 50.0, 9 },
                    { 6, 1, "table salt", 10.0, 9 },
                    { 7, 1, "instant yeast", 9.0, 9 }
                });

            migrationBuilder.InsertData(
                table: "RecipeSteps",
                columns: new[] { "RecipeId", "StepId", "Photo", "Step" },
                values: new object[,]
                {
                    { 1, 1, null, "Weigh your flour; or measure it by gently spooning it into a cup, then sweeping off any excess." },
                    { 1, 2, null, "To make the dough: Mix and knead all of the dough ingredients — by hand, mixer, or bread machine — to make a soft, smooth dough." },
                    { 1, 3, null, "Cover the dough and let it rise until it's nearly doubled in bulk, about 1 to 2 hours." },
                    { 1, 4, null, "To shape the buns: Gently deflate the dough and divide it into eight pieces (about 100g each); to make smaller or larger buns see \"tips,\" below. Shape each piece into a ball." },
                    { 1, 5, null, "Flatten each dough ball with the palm of your hand until it's about 3\" across." },
                    { 1, 6, null, "Place the buns on a lightly greased or parchment-lined baking sheet. Cover and let rise until noticeably puffy, about an hour. Toward the end of the rising time, preheat the oven to 375°F." },
                    { 1, 7, null, "Brush the buns with about half of the melted butter. To make seeded buns, brush the egg white/water mixture right over the melted butter; it'll make the seeds adhere. Sprinkle buns with the seeds of your choice." },
                    { 1, 8, null, "To bake the buns: Bake the buns for 15 to 18 minutes, until golden. Remove them from the oven and brush with the remaining melted butter; this will give the buns a satiny, buttery crust. If you've made seeded buns apply the melted butter carefully, to avoid brushing the seeds off the buns." },
                    { 1, 9, null, "Cool the buns on a rack before slicing in half, horizontally. Use as a base for burgers (beef or plant-based) or any favorite sandwich filling." },
                    { 1, 10, null, "Storage information: Store leftover buns, well-wrapped, at room temperature for several days; freeze for longer storage." }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "RecipeIngredients",
                keyColumns: new[] { "IngredientId", "RecipeId" },
                keyValues: new object[] { 1, 1 });

            migrationBuilder.DeleteData(
                table: "RecipeIngredients",
                keyColumns: new[] { "IngredientId", "RecipeId" },
                keyValues: new object[] { 2, 1 });

            migrationBuilder.DeleteData(
                table: "RecipeIngredients",
                keyColumns: new[] { "IngredientId", "RecipeId" },
                keyValues: new object[] { 3, 1 });

            migrationBuilder.DeleteData(
                table: "RecipeIngredients",
                keyColumns: new[] { "IngredientId", "RecipeId" },
                keyValues: new object[] { 4, 1 });

            migrationBuilder.DeleteData(
                table: "RecipeIngredients",
                keyColumns: new[] { "IngredientId", "RecipeId" },
                keyValues: new object[] { 5, 1 });

            migrationBuilder.DeleteData(
                table: "RecipeIngredients",
                keyColumns: new[] { "IngredientId", "RecipeId" },
                keyValues: new object[] { 6, 1 });

            migrationBuilder.DeleteData(
                table: "RecipeIngredients",
                keyColumns: new[] { "IngredientId", "RecipeId" },
                keyValues: new object[] { 7, 1 });

            migrationBuilder.DeleteData(
                table: "RecipeSteps",
                keyColumns: new[] { "RecipeId", "StepId" },
                keyValues: new object[] { 1, 1 });

            migrationBuilder.DeleteData(
                table: "RecipeSteps",
                keyColumns: new[] { "RecipeId", "StepId" },
                keyValues: new object[] { 1, 2 });

            migrationBuilder.DeleteData(
                table: "RecipeSteps",
                keyColumns: new[] { "RecipeId", "StepId" },
                keyValues: new object[] { 1, 3 });

            migrationBuilder.DeleteData(
                table: "RecipeSteps",
                keyColumns: new[] { "RecipeId", "StepId" },
                keyValues: new object[] { 1, 4 });

            migrationBuilder.DeleteData(
                table: "RecipeSteps",
                keyColumns: new[] { "RecipeId", "StepId" },
                keyValues: new object[] { 1, 5 });

            migrationBuilder.DeleteData(
                table: "RecipeSteps",
                keyColumns: new[] { "RecipeId", "StepId" },
                keyValues: new object[] { 1, 6 });

            migrationBuilder.DeleteData(
                table: "RecipeSteps",
                keyColumns: new[] { "RecipeId", "StepId" },
                keyValues: new object[] { 1, 7 });

            migrationBuilder.DeleteData(
                table: "RecipeSteps",
                keyColumns: new[] { "RecipeId", "StepId" },
                keyValues: new object[] { 1, 8 });

            migrationBuilder.DeleteData(
                table: "RecipeSteps",
                keyColumns: new[] { "RecipeId", "StepId" },
                keyValues: new object[] { 1, 9 });

            migrationBuilder.DeleteData(
                table: "RecipeSteps",
                keyColumns: new[] { "RecipeId", "StepId" },
                keyValues: new object[] { 1, 10 });

            migrationBuilder.DeleteData(
                table: "ServesDescriptors",
                keyColumn: "ServesDescriptorId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Units",
                keyColumn: "UnitID",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Units",
                keyColumn: "UnitID",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Units",
                keyColumn: "UnitID",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Units",
                keyColumn: "UnitID",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Units",
                keyColumn: "UnitID",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Units",
                keyColumn: "UnitID",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Units",
                keyColumn: "UnitID",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Units",
                keyColumn: "UnitID",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Units",
                keyColumn: "UnitID",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Units",
                keyColumn: "UnitID",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Units",
                keyColumn: "UnitID",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "Units",
                keyColumn: "UnitID",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "Recipes",
                keyColumn: "RecipeId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Units",
                keyColumn: "UnitID",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Units",
                keyColumn: "UnitID",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "ServesDescriptors",
                keyColumn: "ServesDescriptorId",
                keyValue: 1);
        }
    }
}
