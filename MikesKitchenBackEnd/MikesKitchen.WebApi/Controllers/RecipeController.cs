using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MikesKitchen.Common.Core.Interfaces;
using MikesKitchen.Common.EntityModels.SqlServer;

namespace MikesKitchen.WebApi.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class RecipeController : ControllerBase
	{
		private readonly IRecipeService _RecipeService;

		public RecipeController(IRecipeService RecipeService)
		{
			_RecipeService = RecipeService;
		}
		// GET: api/<RecipeController>
		[HttpGet]
		public IEnumerable<Recipe> Get()
		{
			return _RecipeService.GetAll();
		}

		// GET api/<RecipeController>/5
		[HttpGet("{id}")]
		public Recipe Get(int id)
		{
			return _RecipeService.Get(id);
		}

		// POST api/<RecipeController>
		[HttpPost]
		public void Post([FromBody] Recipe Recipe)
		{
			_RecipeService.Create(Recipe);
		}

		// PUT api/<RecipeController>/5
		[HttpPut]
		public void Put([FromBody] Recipe Recipe)
		{
			_RecipeService.Update(Recipe);
		}

		// DELETE api/<RecipeController>/5
		[HttpDelete("{id}")]
		public void Delete(int id)
		{
			_RecipeService.Delete(id);
		}
	}
}
