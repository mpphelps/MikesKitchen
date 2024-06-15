using MikesKitchen.Common.EntityModels.SqlServer;

namespace MikesKitchen.Common.DataContext.SqlServer.Interfaces;

public interface IUserRepository
{
	User Create(User user);

	IEnumerable<User> GetAll();

	User Get(int id);

	User Update(User user);

	bool Delete(int id);

}
