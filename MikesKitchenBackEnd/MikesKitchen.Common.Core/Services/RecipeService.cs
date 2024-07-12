using MikesKitchen.Common.Core.Interfaces;
using MikesKitchen.Common.DataContext.SqlServer.Interfaces;
using MikesKitchen.Common.EntityModels.SqlServer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MikesKitchen.Common.Core.Services;

public class RecipeService : IRecipeService
{
	private IRecipeRepository _RecipeRepository;
	public RecipeService(IRecipeRepository RecipeRepository)
	{
		_RecipeRepository = RecipeRepository;

	}
	public Recipe Create(Recipe Recipe)
	{
		try
		{
			return _RecipeRepository.Create(Recipe);
		}
		catch (Exception)
		{
			// todo: add logger here
			throw;
		}
	}

	public IEnumerable<Recipe> GetAll()
	{
		try
		{
			return _RecipeRepository.GetAll();
		}
		catch (Exception)
		{
			// todo: add logger here
			throw;
		}
	}

	public Recipe Get(int id)
	{
		try
		{
			return _RecipeRepository.Get(id);
		}
		catch (Exception)
		{
			// todo: add logger here
			throw;
		}
	}

	public Recipe Update(Recipe Recipe)
	{
		try
		{
			return _RecipeRepository.Update(Recipe);
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
			return _RecipeRepository.Delete(id);
		}
		catch (Exception)
		{
			// todo: add logger here
			throw;
		}
	}
}
