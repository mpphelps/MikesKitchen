using Microsoft.EntityFrameworkCore;
using MikesKitchen.Common.DataContext.SqlServer;
using MikesKitchen.Common.EntityModels.SqlServer;

public static class Program
{
	public static async Task Main(string[] args)
	{
		var test = new MikesKitchenDatabaseTest();
		//test.PrintRecipe(1);
		test.AddTestUser();
		test.RemoveTestUser();
		await test.AddTestUserAsync();
		await test.RemoveTestUserAsync();
	}
}

public class MikesKitchenDatabaseTest
{
	
	public void PrintRecipe(int id)
	{
		using (MikesKitchenContext db = new MikesKitchenContext())
		{
			foreach (Recipe recipe in db.Recipes.Include(r => r.RecipeSteps)
				.Include(r => r.User).Where(r => r.RecipeId == id))
			{
				Console.WriteLine($"Recipe Title: {recipe.Title} by {recipe.User.FirstName} {recipe.User.LastName}\n");
				foreach (RecipeStep step in recipe.RecipeSteps)
				{
					Console.WriteLine($"{step.StepId}: {step.Step}\n");
				}
			}
		}
	}

    private User TestUser { 
		get {
			return new User()
			{
				Email = "test@test.com",
				UserName = "Test",
				FirstName = "Testfirstname",
				LastName = "Testlastname",
				Password = "Password"
			};
		}
		set { } 
	}

    public void AddTestUser()
	{
		using (MikesKitchenContext db = new MikesKitchenContext())
		{
			db.Users?.Add(TestUser);
			int affected = db.SaveChanges();
			if (affected == 1)
                Console.WriteLine($"Test user added");
            else
				Console.WriteLine($"Failed to add test user.  Affected entries: {affected}");
        }
	}

	public async Task AddTestUserAsync()
	{
		using (MikesKitchenContext db = new MikesKitchenContext())
		{
			db.Users?.Add(TestUser);
			var affected = await db.SaveChangesAsync();
			if (affected == 1)
				Console.WriteLine($"Test user added");
			else
				Console.WriteLine($"Failed to add test user.  Affected entries: {affected}");
		}
	}

	public void RemoveTestUser()
	{
		using (MikesKitchenContext db = new MikesKitchenContext())
		{
			var testUser = db.Users.FirstOrDefault(u => u.Email == TestUser.Email);

			if (testUser == null)
			{
				Console.Out.WriteLine("Test user not found");
				return;
			}

			db.Users.Remove(testUser);
			int affected = db.SaveChanges(true);
			if (affected == 1)
				Console.WriteLine($"Test user removed");
			else
				Console.WriteLine($"Failed to remove test user.  Affected entries: {affected}");
		}
	}

	public async Task RemoveTestUserAsync()
	{
		using (MikesKitchenContext db = new MikesKitchenContext())
		{
			var testUser = await db.Users.FirstOrDefaultAsync(u => u.Email == TestUser.Email);

			if (testUser == null)
			{
                await Console.Out.WriteLineAsync("Test user not found");
				return;
            }

			db.Users.Remove(testUser);
			int affected = await db.SaveChangesAsync(true);
			if (affected == 1)
				Console.WriteLine("Test user removed");
			else
				Console.WriteLine($"Failed to remove test user. Affected entries: {affected}");
		}
	}
}