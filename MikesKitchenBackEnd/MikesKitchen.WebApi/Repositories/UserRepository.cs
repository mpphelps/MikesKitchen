using Microsoft.EntityFrameworkCore;
using MikesKitchen.Common;

namespace MikesKitchen.WebApi.Repositories
{
	public class UserRepository : IUserRepository
	{
		public async Task<User?> CreateAsync(User user)
		{
			using (MikesKitchenContext db = new MikesKitchenContext())
			{
				db.Users?.Add(user);
				var affected = await db.SaveChangesAsync();
				if (affected == 1)
					Console.WriteLine($"User added");
				else
					Console.WriteLine($"Failed to add Uuser.  Affected entries: {affected}");
			}
			return user;
		}

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

		async public Task<bool?> DeleteAsync(int id)
		{
			using (MikesKitchenContext db = new MikesKitchenContext())
			{
				var user = await db.Users.FirstOrDefaultAsync(u => u.UserId == id);

				if (user == null)
				{
					await Console.Out.WriteLineAsync("User not found");
					return false;
				}

				db.Users.Remove(user);
				int affected = await db.SaveChangesAsync(true);
				if (affected == 1)
					Console.WriteLine("User removed");
				else
					Console.WriteLine($"Failed to remove user. Affected entries: {affected}");
			}
			return true;
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

		async public Task<IEnumerable<User>> GetAllAsync()
		{
			throw new NotImplementedException();
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

		async public Task<User?> GetAsync(int id)
		{
			throw new NotImplementedException();
		}

		public User Get(int id)
		{
			User user;
			using (MikesKitchenContext db = new MikesKitchenContext())
			{
				user = db.Users.First(u => u.UserId == id);
			}
			return user;
		}

		async public Task<User?> UpdateAsync(int id, User user)
		{
			throw new NotImplementedException();
		}

		public User Update(User user)
		{
			throw new NotImplementedException();
		}
	}
}
