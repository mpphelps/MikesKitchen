using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MikesKitchen.Common.EntityModels.SqlServer;

namespace MikesKitchen.Common.Core.Interfaces;

public interface IUserService
{
	User Create(User user);

	IEnumerable<User> GetAll();

	User Get(int id);

	User Update(User user);

	bool Delete(int id);
}
