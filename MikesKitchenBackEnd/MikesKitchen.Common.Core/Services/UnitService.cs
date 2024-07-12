using MikesKitchen.Common.Core.Interfaces;
using MikesKitchen.Common.DataContext.SqlServer.Interfaces;
using MikesKitchen.Common.EntityModels.SqlServer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MikesKitchen.Common.Core.Services;

public class UnitService : IUnitService
{
	private IUnitRepository _UnitRepository;
	public UnitService(IUnitRepository UnitRepository)
	{
		_UnitRepository = UnitRepository;

	}
	public Unit Create(Unit Unit)
	{
		try
		{
			return _UnitRepository.Create(Unit);
		}
		catch (Exception)
		{
			// todo: add logger here
			throw;
		}
	}

	public IEnumerable<Unit> GetAll()
	{
		try
		{
			return _UnitRepository.GetAll();
		}
		catch (Exception)
		{
			// todo: add logger here
			throw;
		}
	}

	public Unit Get(int id)
	{
		try
		{
			return _UnitRepository.Get(id);
		}
		catch (Exception)
		{
			// todo: add logger here
			throw;
		}
	}

	public Unit Update(Unit Unit)
	{
		try
		{
			return _UnitRepository.Update(Unit);
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
			return _UnitRepository.Delete(id);
		}
		catch (Exception)
		{
			// todo: add logger here
			throw;
		}
	}
}
