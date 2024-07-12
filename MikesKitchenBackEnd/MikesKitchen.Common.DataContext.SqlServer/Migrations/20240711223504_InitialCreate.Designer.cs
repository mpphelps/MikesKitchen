﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using MikesKitchen.Common.DataContext.SqlServer;

#nullable disable

namespace MikesKitchen.Common.DataContext.SqlServer.Migrations
{
    [DbContext(typeof(MikesKitchenContext))]
    [Migration("20240711223504_InitialCreate")]
    partial class InitialCreate
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.20")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Favorite", b =>
                {
                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.Property<int>("RecipeId")
                        .HasColumnType("int");

                    b.HasKey("UserId", "RecipeId")
                        .HasName("PK_RecipeFavorites");

                    b.HasIndex("RecipeId");

                    b.ToTable("Favorites", (string)null);
                });

            modelBuilder.Entity("MikesKitchen.Common.EntityModels.SqlServer.Recipe", b =>
                {
                    b.Property<int>("RecipeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("RecipeId"));

                    b.Property<int>("CookTime")
                        .HasColumnType("int");

                    b.Property<byte[]>("Photo")
                        .HasColumnType("image");

                    b.Property<int>("PrepTime")
                        .HasColumnType("int");

                    b.Property<int>("ServesDescriptorId")
                        .HasColumnType("int");

                    b.Property<int>("ServesQuantity")
                        .HasColumnType("int");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("RecipeId")
                        .HasName("PK__Recipes__FDD988B08DADB37A");

                    b.HasIndex("ServesDescriptorId");

                    b.HasIndex("UserId");

                    b.ToTable("Recipes");
                });

            modelBuilder.Entity("MikesKitchen.Common.EntityModels.SqlServer.RecipeIngredient", b =>
                {
                    b.Property<int>("RecipeId")
                        .HasColumnType("int");

                    b.Property<int>("IngredientId")
                        .HasColumnType("int");

                    b.Property<string>("Ingredient")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<double>("Quantity")
                        .HasColumnType("float");

                    b.Property<int>("UnitId")
                        .HasColumnType("int")
                        .HasColumnName("UnitID");

                    b.HasKey("RecipeId", "IngredientId")
                        .HasName("PK_RecipeIngredient");

                    b.HasIndex("UnitId");

                    b.ToTable("RecipeIngredients");
                });

            modelBuilder.Entity("MikesKitchen.Common.EntityModels.SqlServer.RecipeStep", b =>
                {
                    b.Property<int>("RecipeId")
                        .HasColumnType("int");

                    b.Property<int>("StepId")
                        .HasColumnType("int");

                    b.Property<byte[]>("Photo")
                        .HasColumnType("image");

                    b.Property<string>("Step")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.HasKey("RecipeId", "StepId")
                        .HasName("PK_RecipeStep");

                    b.ToTable("RecipeSteps");
                });

            modelBuilder.Entity("MikesKitchen.Common.EntityModels.SqlServer.ServesDescriptor", b =>
                {
                    b.Property<int>("ServesDescriptorId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ServesDescriptorId"));

                    b.Property<string>("ServesDescriptor1")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasColumnName("ServesDescriptor");

                    b.HasKey("ServesDescriptorId")
                        .HasName("PK__ServesDe__F4B29F657004D445");

                    b.ToTable("ServesDescriptors");
                });

            modelBuilder.Entity("MikesKitchen.Common.EntityModels.SqlServer.Unit", b =>
                {
                    b.Property<int>("UnitId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("UnitID");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("UnitId"));

                    b.Property<string>("UnitDescriptor")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)");

                    b.HasKey("UnitId");

                    b.ToTable("Units");
                });

            modelBuilder.Entity("MikesKitchen.Common.EntityModels.SqlServer.User", b =>
                {
                    b.Property<int>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("UserId"));

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("UserId");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("RecipeUser", b =>
                {
                    b.Property<int>("RecipeId")
                        .HasColumnType("int");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("RecipeId", "UserId");

                    b.ToTable("RecipeUser");
                });

            modelBuilder.Entity("Favorite", b =>
                {
                    b.HasOne("MikesKitchen.Common.EntityModels.SqlServer.Recipe", null)
                        .WithMany()
                        .HasForeignKey("RecipeId")
                        .IsRequired()
                        .HasConstraintName("FK_RecipeFavorites_RecipeId");

                    b.HasOne("MikesKitchen.Common.EntityModels.SqlServer.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .IsRequired()
                        .HasConstraintName("FK_RecipeFavorites_UserId");
                });

            modelBuilder.Entity("MikesKitchen.Common.EntityModels.SqlServer.Recipe", b =>
                {
                    b.HasOne("MikesKitchen.Common.EntityModels.SqlServer.ServesDescriptor", "ServesDescriptor")
                        .WithMany("Recipes")
                        .HasForeignKey("ServesDescriptorId")
                        .IsRequired()
                        .HasConstraintName("FK_ServesID");

                    b.HasOne("MikesKitchen.Common.EntityModels.SqlServer.User", "User")
                        .WithMany("RecipesNavigation")
                        .HasForeignKey("UserId")
                        .IsRequired()
                        .HasConstraintName("FK_UserId");

                    b.Navigation("ServesDescriptor");

                    b.Navigation("User");
                });

            modelBuilder.Entity("MikesKitchen.Common.EntityModels.SqlServer.RecipeIngredient", b =>
                {
                    b.HasOne("MikesKitchen.Common.EntityModels.SqlServer.Recipe", "Recipe")
                        .WithMany("RecipeIngredients")
                        .HasForeignKey("RecipeId")
                        .IsRequired()
                        .HasConstraintName("FK_RecipeIngredients_RecipeId");

                    b.HasOne("MikesKitchen.Common.EntityModels.SqlServer.Unit", "Unit")
                        .WithMany("RecipeIngredients")
                        .HasForeignKey("UnitId")
                        .IsRequired()
                        .HasConstraintName("FK_RecipeIngredients_UnitId");

                    b.Navigation("Recipe");

                    b.Navigation("Unit");
                });

            modelBuilder.Entity("MikesKitchen.Common.EntityModels.SqlServer.RecipeStep", b =>
                {
                    b.HasOne("MikesKitchen.Common.EntityModels.SqlServer.Recipe", "Recipe")
                        .WithMany("RecipeSteps")
                        .HasForeignKey("RecipeId")
                        .IsRequired()
                        .HasConstraintName("FK_RecipeSteps_RecipeId");

                    b.Navigation("Recipe");
                });

            modelBuilder.Entity("MikesKitchen.Common.EntityModels.SqlServer.Recipe", b =>
                {
                    b.Navigation("RecipeIngredients");

                    b.Navigation("RecipeSteps");
                });

            modelBuilder.Entity("MikesKitchen.Common.EntityModels.SqlServer.ServesDescriptor", b =>
                {
                    b.Navigation("Recipes");
                });

            modelBuilder.Entity("MikesKitchen.Common.EntityModels.SqlServer.Unit", b =>
                {
                    b.Navigation("RecipeIngredients");
                });

            modelBuilder.Entity("MikesKitchen.Common.EntityModels.SqlServer.User", b =>
                {
                    b.Navigation("RecipesNavigation");
                });
#pragma warning restore 612, 618
        }
    }
}
