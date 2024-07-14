using Microsoft.EntityFrameworkCore;
using MikesKitchen.Common.DataContext.SqlServer.Interfaces;
using MikesKitchen.Common.EntityModels.SqlServer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MikesKitchen.Common.DataContext.SqlServer.Repositories;

public class RecipeRepository : IRecipeRepository
{
	public Recipe Create(Recipe Recipe)
	{
		using (MikesKitchenContext db = new MikesKitchenContext())
		{
			db.Recipes?.Add(Recipe);
			int affected = db.SaveChanges();
			if (affected == 1)
				Console.WriteLine($"Recipe added");
			else
				Console.WriteLine($"Failed to add Recipe.  Affected entries: {affected}");
		}
		return Recipe;
	}

	public bool Delete(int id)
	{
		using (MikesKitchenContext db = new MikesKitchenContext())
		{
			var Recipe = db.Recipes.FirstOrDefault(u => u.RecipeId == id);

			if (Recipe == null)
			{
				Console.Out.WriteLine("Recipe not found");
				return false;
			}

			db.Recipes.Remove(Recipe);
			int affected = db.SaveChanges(true);
			if (affected == 1)
				Console.WriteLine($"Recipe removed");
			else
				Console.WriteLine($"Failed to remove Recipe.  Affected entries: {affected}");
		}
		return true;
	}

	public IEnumerable<Recipe> GetAll()
	{
		List<Recipe> Recipes;
		using (MikesKitchenContext db = new MikesKitchenContext())
		{
			Recipes = db.Recipes.ToList<Recipe>();
		}
		return Recipes;
	}

	public Recipe Get(int id)
	{
		using (MikesKitchenContext db = new MikesKitchenContext())
		{
			var recipe = db.Recipes
				.Include(r => r.ServesDescriptor)
				.Include(r => r.RecipeSteps)
				.Include(r => r.RecipeIngredients).ThenInclude(ri => ri.Unit)
				.FirstOrDefault(r => r.RecipeId == id);

			if (recipe == null)
			{
				throw new Exception($"Recipe with ID {id} not found.");
			}

			return recipe;
		}
	}

	public Recipe Update(Recipe Recipe)
	{
		using (MikesKitchenContext db = new MikesKitchenContext())
		{
			var existingRecipe = db.Recipes.First(u => u.RecipeId == Recipe.RecipeId);
			if (existingRecipe != null)
			{
				existingRecipe.Title = Recipe.Title;
				existingRecipe.ServesDescriptorId = Recipe.ServesDescriptorId;
				existingRecipe.ServesQuantity = Recipe.ServesQuantity;
				existingRecipe.PrepTime = Recipe.PrepTime;
				existingRecipe.CookTime = Recipe.CookTime;
				existingRecipe.Photo = Recipe.Photo;
				existingRecipe.RecipeIngredients = Recipe.RecipeIngredients;
				existingRecipe.RecipeSteps = Recipe.RecipeSteps;
				db.SaveChanges();
			}
			else
			{
				throw new Exception($"Recipe {Recipe.Title} does not exist");
			}
		}
		return Recipe;
	}
}
