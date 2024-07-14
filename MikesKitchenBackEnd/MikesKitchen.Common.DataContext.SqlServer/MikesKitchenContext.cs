using Microsoft.EntityFrameworkCore;
using MikesKitchen.Common.EntityModels.SqlServer;

namespace MikesKitchen.Common.DataContext.SqlServer;

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

			entity.HasOne(d => d.ServesDescriptor);

			entity.HasOne(r => r.User)
			.WithMany(u => u.Recipes)
			.HasForeignKey(r => r.UserId)
			.OnDelete(DeleteBehavior.ClientSetNull);

            entity.HasData(new Recipe
            {
                RecipeId = 1,
                UserId = 1,
                Title = "Beautiful Burger Buns",
                ServesDescriptorId = 1,
                ServesQuantity = 1,
                PrepTime = 25,
                CookTime = 15,
            });
        });

        modelBuilder.Entity<RecipeIngredient>(entity =>
        {
            entity.HasKey(e => new { e.RecipeId, e.IngredientId }).HasName("PK_RecipeIngredient");

			entity.HasOne(d => d.Unit);

			entity.HasData(new RecipeIngredient
			{
				RecipeId = 1,
				IngredientId = 1,
				Ingredient = "King Arthur Unbleached All-Purpose Flour",
				Quantity = 420,
				UnitId = 9
			},
			new RecipeIngredient
			{
				RecipeId = 1,
				IngredientId = 2,
				Ingredient = "water, lukewarm",
				Quantity = 227,
				UnitId = 9
			},
			new RecipeIngredient
			{
				RecipeId = 1,
				IngredientId = 3,
				Ingredient = "butter, at room temperature\r\n",
				Quantity = 28,
				UnitId = 9
			},
			new RecipeIngredient
			{
				RecipeId = 1,
				IngredientId = 4,
				Ingredient = "large egg",
				Quantity = 1,
				UnitId = 1
			},
			new RecipeIngredient
			{
				RecipeId = 1,
				IngredientId = 5,
				Ingredient = "granulated sugar",
				Quantity = 50,
				UnitId = 9
			},
			new RecipeIngredient
			{
				RecipeId = 1,
				IngredientId = 6,
				Ingredient = "table salt",
				Quantity = 10,
				UnitId = 9
			},
			new RecipeIngredient
			{
				RecipeId = 1,
				IngredientId = 7,
				Ingredient = "instant yeast",
				Quantity = 9,
				UnitId = 9
			});
        });

        modelBuilder.Entity<RecipeStep>(entity =>
        {
            entity.HasKey(e => new { e.RecipeId, e.StepId }).HasName("PK_RecipeStep");

			entity.HasData(new RecipeStep
			{
				RecipeId = 1,
				StepId = 1,
				Step = "Weigh your flour; or measure it by gently spooning it into a cup, then sweeping off any excess."
			},
			new RecipeStep
			{
				RecipeId = 1,
				StepId = 2,
				Step = "To make the dough: Mix and knead all of the dough ingredients — by hand, mixer, or bread machine — to make a soft, smooth dough."
			},
			new RecipeStep
			{
				RecipeId = 1,
				StepId = 3,
				Step = "Cover the dough and let it rise until it's nearly doubled in bulk, about 1 to 2 hours."
			},
			new RecipeStep
			{
				RecipeId = 1,
				StepId = 4,
				Step = "To shape the buns: Gently deflate the dough and divide it into eight pieces (about 100g each); to make smaller or larger buns see \"tips,\" below. Shape each piece into a ball."
			},
			new RecipeStep
			{
				RecipeId = 1,
				StepId = 5,
				Step = "Flatten each dough ball with the palm of your hand until it's about 3\" across."
			},
			new RecipeStep
			{
				RecipeId = 1,
				StepId = 6,
				Step = "Place the buns on a lightly greased or parchment-lined baking sheet. Cover and let rise until noticeably puffy, about an hour. Toward the end of the rising time, preheat the oven to 375°F."
			},
			new RecipeStep
			{
				RecipeId = 1,
				StepId = 7,
				Step = "Brush the buns with about half of the melted butter. To make seeded buns, brush the egg white/water mixture right over the melted butter; it'll make the seeds adhere. Sprinkle buns with the seeds of your choice."
			},
			new RecipeStep
			{
				RecipeId = 1,
				StepId = 8,
				Step = "To bake the buns: Bake the buns for 15 to 18 minutes, until golden. Remove them from the oven and brush with the remaining melted butter; this will give the buns a satiny, buttery crust. If you've made seeded buns apply the melted butter carefully, to avoid brushing the seeds off the buns."
			},
			new RecipeStep
			{
				RecipeId = 1,
				StepId = 9,
				Step = "Cool the buns on a rack before slicing in half, horizontally. Use as a base for burgers (beef or plant-based) or any favorite sandwich filling."
			},
			new RecipeStep
			{
				RecipeId = 1,
				StepId = 10,
				Step = "Storage information: Store leftover buns, well-wrapped, at room temperature for several days; freeze for longer storage."
			});
        });

        modelBuilder.Entity<ServesDescriptor>(entity =>
        {
            entity.HasKey(e => e.ServesDescriptorId).HasName("PK__ServesDe__F4B29F657004D445");

            //entity.Property(e => e.ServesDescriptorId).ValueGeneratedNever();

            entity.HasData(new ServesDescriptor
            {
                ServesDescriptorId = 1,
                ServesDescriptor1 = "Yields"
            },
			new ServesDescriptor
			{
				ServesDescriptorId = 2,
				ServesDescriptor1 = "Makes"
			});
        });

        modelBuilder.Entity<Unit>(entity =>
        {
            //entity.Property(e => e.UnitId).ValueGeneratedNever();

            entity.HasData(new Unit
            {
                UnitId = 1,
                UnitDescriptor = "ea"
            },
            new Unit
            {
				UnitId = 2,
				UnitDescriptor = "tsp"
			},
			new Unit
			{
				UnitId = 3,
				UnitDescriptor = "tbsp"
			},
			new Unit
			{
				UnitId = 4,
				UnitDescriptor = "cup"
			},
			new Unit
			{
				UnitId = 5,
				UnitDescriptor = "pt"
			},
			new Unit
			{
				UnitId = 6,
				UnitDescriptor = "qt"
			},
			new Unit
			{
				UnitId = 7,
				UnitDescriptor = "gal"
			},
			new Unit
			{
				UnitId = 8,
				UnitDescriptor = "oz"
			},
			new Unit
			{
				UnitId = 9,
				UnitDescriptor = "g"
			},
			new Unit
			{
				UnitId = 10,
				UnitDescriptor = "kg"
			},
			new Unit
			{
				UnitId = 11,
				UnitDescriptor = "fl oz"
			},
			new Unit
			{
				UnitId = 12,
				UnitDescriptor = "lbs"
			},
			new Unit
			{
				UnitId = 13,
				UnitDescriptor = "ml"
			}
			,
			new Unit
			{
				UnitId = 14,
				UnitDescriptor = "l"
			});
        });

        modelBuilder.Entity<User>(entity =>
        {
			//entity.Property(e => e.UserId).ValueGeneratedNever();

			entity.HasMany(u => u.Recipes)
			.WithOne(r => r.User)
			.HasForeignKey(u => u.UserId)
			.OnDelete(DeleteBehavior.Restrict);

			entity.HasData(new User
            {
                UserId = 2,
                FirstName = "Sofia",
                LastName = "Lazaro",
                Email = "sclazaro@gmail.com",
                Password = "Password",
                UserName = "sclazaro",
            }, new User
            {
				UserId = 1,
				FirstName = "Michael",
				LastName = "Phelps",
				Email = "mpphelps@gmail.com",
				Password = "Password",
				UserName = "mpphelps",
			});
		});

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
