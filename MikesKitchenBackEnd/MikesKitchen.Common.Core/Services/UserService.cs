using MikesKitchen.Common.Core.Interfaces;
using MikesKitchen.Common.DataContext.SqlServer.Interfaces;
using MikesKitchen.Common.EntityModels.SqlServer;

namespace MikesKitchen.Common.Core.Services
{
	public class UserService : IUserService
	{
		private IUserRepository _userRepository;
        public UserService(IUserRepository userRepository)
        {
			_userRepository = userRepository;

		}
        public User Create(User user)
		{
			try
			{
				return _userRepository.Create(user);
			}
			catch (Exception)
			{
				// todo: add logger here
				throw;
			}
		}

		public IEnumerable<User> GetAll()
		{
			try
			{
				return _userRepository.GetAll();
			}
			catch (Exception)
			{
				// todo: add logger here
				throw;
			}
		}

		public User Get(int id)
		{
			try
			{
				return _userRepository.Get(id);
			}
			catch (Exception)
			{
				// todo: add logger here
				throw;
			}
		}

		public User Update(User user)
		{
			try
			{
				return _userRepository.Update(user);
			}
			catch (Exception)
			{
				// todo: add logger here
				throw;
			}
		}

		public bool Delete(int id)
		{
			try
			{
				return _userRepository.Delete(id);
			}
			catch (Exception)
			{
				// todo: add logger here
				throw;
			}
		}		
	}
}