using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace MikesKitchen.Common.DataContext.SqlServer.Migrations
{
    /// <inheritdoc />
    public partial class AddUserSeedData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder) 
        {
            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "UserId", "Email", "FirstName", "LastName", "Password", "UserName" },
                values: new object[,]
                {
                    { 1, "mpphelps@gmail.com", "Michael", "Phelps", "Password", "mpphelps" },
                    { 2, "sclazaro@gmail.com", "Sofia", "Lazaro", "Password", "sclazaro" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 2);
        }
    }
}
