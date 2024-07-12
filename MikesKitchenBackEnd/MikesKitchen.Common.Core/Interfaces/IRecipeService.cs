using MikesKitchen.Common.EntityModels.SqlServer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MikesKitchen.Common.Core.Interfaces;

public interface IRecipeService
{
	Recipe Create(Recipe Recipe);

	IEnumerable<Recipe> GetAll();

	Recipe Get(int id);

	Recipe Update(Recipe Recipe);

	bool Delete(int id);
}
