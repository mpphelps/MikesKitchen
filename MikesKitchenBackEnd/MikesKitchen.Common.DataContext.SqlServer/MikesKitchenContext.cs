using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace MikesKitchen.Common;

public partial class MikesKitchenContext : DbContext
{
    public MikesKitchenContext()
    {
    }

    public MikesKitchenContext(DbContextOptions<MikesKitchenContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Recipe> Recipes { get; set; }

    public virtual DbSet<RecipeIngredient> RecipeIngredients { get; set; }

    public virtual DbSet<RecipeStep> RecipeSteps { get; set; }

    public virtual DbSet<ServesDescriptor> ServesDescriptors { get; set; }

    public virtual DbSet<Unit> Units { get; set; }

    public virtual DbSet<User> Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlServer("Data Source=.;Initial Catalog=MikesKitchen;Integrated Security=true;Encrypt=false");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Recipe>(entity =>
        {
            entity.HasKey(e => e.RecipeId).HasName("PK__Recipes__FDD988B08DADB37A");

            //entity.Property(e => e.RecipeId).ValueGeneratedNever();

            entity.HasOne(d => d.ServesDescriptor).WithMany(p => p.Recipes)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ServesID");

            entity.HasOne(d => d.User).WithMany(p => p.RecipesNavigation)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_UserId");
        });

        modelBuilder.Entity<RecipeIngredient>(entity =>
        {
            entity.HasKey(e => new { e.RecipeId, e.IngredientId }).HasName("PK_RecipeIngredient");

            entity.HasOne(d => d.Recipe).WithMany(p => p.RecipeIngredients)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_RecipeIngredients_RecipeId");

            entity.HasOne(d => d.Unit).WithMany(p => p.RecipeIngredients)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_RecipeIngredients_UnitId");
        });

        modelBuilder.Entity<RecipeStep>(entity =>
        {
            entity.HasKey(e => new { e.RecipeId, e.StepId }).HasName("PK_RecipeStep");

            entity.HasOne(d => d.Recipe).WithMany(p => p.RecipeSteps)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_RecipeSteps_RecipeId");
        });

        modelBuilder.Entity<ServesDescriptor>(entity =>
        {
            entity.HasKey(e => e.ServesDescriptorId).HasName("PK__ServesDe__F4B29F657004D445");

            //entity.Property(e => e.ServesDescriptorId).ValueGeneratedNever();
        });

        modelBuilder.Entity<Unit>(entity =>
        {
            //entity.Property(e => e.UnitId).ValueGeneratedNever();
        });

        modelBuilder.Entity<User>(entity =>
        {
            //entity.Property(e => e.UserId).ValueGeneratedNever();

            entity.HasMany(d => d.Recipes).WithMany(p => p.Users)
                .UsingEntity<Dictionary<string, object>>(
                    "Favorite",
                    r => r.HasOne<Recipe>().WithMany()
                        .HasForeignKey("RecipeId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK_RecipeFavorites_RecipeId"),
                    l => l.HasOne<User>().WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK_RecipeFavorites_UserId"),
                    j =>
                    {
                        j.HasKey("UserId", "RecipeId").HasName("PK_RecipeFavorites");
                        j.ToTable("Favorites");
                    });
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
