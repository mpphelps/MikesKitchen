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
		public ActionResult<List<Recipe>> Get()
		{
			var recipes = _RecipeService.GetAll().ToList();
			return Ok(recipes);
		}

		// GET api/<RecipeController>/5
		[HttpGet("{id}")]
		public ActionResult<Recipe> Get(int id)
		{
			var recipe = _RecipeService.Get(id);
			return Ok(recipe);
		}

		// POST api/<RecipeController>
		[HttpPost]
		public ActionResult Post([FromBody] Recipe Recipe)
		{
			_RecipeService.Create(Recipe);
			return Ok();
		}

		// PUT api/<RecipeController>/5
		[HttpPut]
		public ActionResult Put([FromBody] Recipe Recipe)
		{
			_RecipeService.Update(Recipe);
			return Ok();
		}

		// DELETE api/<RecipeController>/5
		[HttpDelete("{id}")]
		public ActionResult Delete(int id)
		{
			_RecipeService.Delete(id);
			return Ok();
		}
	}
}
