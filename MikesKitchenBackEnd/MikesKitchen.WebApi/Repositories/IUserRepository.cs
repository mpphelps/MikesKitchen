using MikesKitchen.Common;

namespace MikesKitchen.WebApi.Repositories
{
	public interface IUserRepository
	{
		Task<User?> CreateAsync(User user);
		User Create(User user);

		Task<IEnumerable<User>> GetAllAsync();
		IEnumerable<User> GetAll();

		Task<User?> GetAsync(int id);
		User Get(int id);

		Task<User?> UpdateAsync(int id, User user);
		User Update(User user);

		Task<bool?> DeleteAsync(int id);
		bool Delete(int id);

	}
}
