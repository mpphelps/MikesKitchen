using MikesKitchen.Common.EntityModels.SqlServer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MikesKitchen.Common.DataContext.SqlServer.Interfaces;

public interface IRecipeRepository
{
	Recipe Create(Recipe Recipe);

	IEnumerable<Recipe> GetAll();

	Recipe Get(int id);

	Recipe Update(Recipe Recipe);

	bool Delete(int id);
}
