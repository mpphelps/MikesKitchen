using Microsoft.EntityFrameworkCore;
using MikesKitchen.Common.DataContext.SqlServer.Interfaces;
using MikesKitchen.Common.EntityModels.SqlServer;

namespace MikesKitchen.Common.DataContext.SqlServer.Repositories;

public class UserRepository : IUserRepository
{
    public User Create(User user)
	{
		using (MikesKitchenContext db = new MikesKitchenContext())
		{
			db.Users?.Add(user);
			int affected = db.SaveChanges();
			if (affected == 1)
				Console.WriteLine($"User added");
			else
				Console.WriteLine($"Failed to add user.  Affected entries: {affected}");
		}
		return user;
	}

	public bool Delete(int id)
	{
		using (MikesKitchenContext db = new MikesKitchenContext())
		{
			var user = db.Users.FirstOrDefault(u => u.UserId == id);

			if (user == null)
			{
				Console.Out.WriteLine("User not found");
				return false;
			}

			db.Users.Remove(user);
			int affected = db.SaveChanges(true);
			if (affected == 1)
				Console.WriteLine($"User removed");
			else
				Console.WriteLine($"Failed to remove user.  Affected entries: {affected}");
		}
		return true;
	}

	public IEnumerable<User> GetAll()
	{
		List<User> users;
		using (MikesKitchenContext db = new MikesKitchenContext())
		{
			users = db.Users.ToList<User>();
		}
		return users;
	}

	public User Get(int id)
	{
		User user;
		using (MikesKitchenContext db = new MikesKitchenContext())
		{
			user = db.Users
				.First(u => u.UserId == id);
		}
		return user;
	}

	public User Update(User user)
	{
		using (MikesKitchenContext db = new MikesKitchenContext())
		{
			var existingUser = db.Users.First(u => u.UserId == user.UserId);
			if (existingUser != null)
			{
				existingUser.FirstName = user.FirstName;
				existingUser.LastName = user.LastName;
				existingUser.Email = user.Email;
				existingUser.Password = user.Password;
				existingUser.UserName = user.UserName;
				db.SaveChanges();
			}
			else
			{
				throw new Exception($"User {user.FirstName} {user.LastName} does not exist");
			}
		}
		return user;
	}
}
