using MikesKitchen.Common.EntityModels.SqlServer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MikesKitchen.Common.Core.Interfaces;

public interface IUnitService
{
	Unit Create(Unit Unit);

	IEnumerable<Unit> GetAll();

	Unit Get(int id);

	Unit Update(Unit Unit);

	bool Delete(int id);
}
