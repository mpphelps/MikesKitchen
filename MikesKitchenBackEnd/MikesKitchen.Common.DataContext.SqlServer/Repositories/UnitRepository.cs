using MikesKitchen.Common.DataContext.SqlServer.Interfaces;
using MikesKitchen.Common.EntityModels.SqlServer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MikesKitchen.Common.DataContext.SqlServer.Repositories;

public class UnitRepository : IUnitRepository
{
	public Unit Create(Unit Unit)
	{
		using (MikesKitchenContext db = new MikesKitchenContext())
		{
			db.Units?.Add(Unit);
			int affected = db.SaveChanges();
			if (affected == 1)
				Console.WriteLine($"Unit added");
			else
				Console.WriteLine($"Failed to add Unit.  Affected entries: {affected}");
		}
		return Unit;
	}

	public bool Delete(int id)
	{
		using (MikesKitchenContext db = new MikesKitchenContext())
		{
			var Unit = db.Units.FirstOrDefault(u => u.UnitId == id);

			if (Unit == null)
			{
				Console.Out.WriteLine("Unit not found");
				return false;
			}

			db.Units.Remove(Unit);
			int affected = db.SaveChanges(true);
			if (affected == 1)
				Console.WriteLine($"Unit removed");
			else
				Console.WriteLine($"Failed to remove Unit.  Affected entries: {affected}");
		}
		return true;
	}

	public IEnumerable<Unit> GetAll()
	{
		List<Unit> Units;
		using (MikesKitchenContext db = new MikesKitchenContext())
		{
			Units = db.Units.ToList<Unit>();
		}
		return Units;
	}

	public Unit Get(int id)
	{
		Unit Unit;
		using (MikesKitchenContext db = new MikesKitchenContext())
		{
			Unit = db.Units.First(u => u.UnitId == id);
		}
		return Unit;
	}

	public Unit Update(Unit Unit)
	{
		using (MikesKitchenContext db = new MikesKitchenContext())
		{
			var existingUnit = db.Units.First(u => u.UnitId == Unit.UnitId);
			if (existingUnit != null)
			{
				existingUnit.UnitDescriptor = Unit.UnitDescriptor;
				db.SaveChanges();
			}
			else
			{
				throw new Exception($"Unit {Unit.UnitDescriptor} does not exist");
			}
		}
		return Unit;
	}
}
