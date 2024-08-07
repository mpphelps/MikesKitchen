using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MikesKitchen.Common.Core.Interfaces;
using MikesKitchen.Common.EntityModels.SqlServer;

namespace MikesKitchen.WebApi.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class UnitController : ControllerBase
	{
		private readonly IUnitService _UnitService;

		public UnitController(IUnitService UnitService)
		{
			_UnitService = UnitService;
		}
		// GET: api/<UnitController>
		[HttpGet]
		public ActionResult<List<Unit>> Get()
		{
			var units = _UnitService.GetAll().ToList();
			return Ok(units);
		}

		// GET api/<UnitController>/5
		[HttpGet("{id}")]
		public ActionResult<Unit> Get(int id)
		{
			var unit = _UnitService.Get(id);
			return Ok(unit);
		}

		// POST api/<UnitController>
		[HttpPost]
		public ActionResult Post([FromBody] Unit Unit)
		{
			_UnitService.Create(Unit);
			return Ok();
		}

		// PUT api/<UnitController>/5
		[HttpPut]
		public ActionResult Put([FromBody] Unit Unit)
		{
			_UnitService.Update(Unit);
			return Ok();
		}

		// DELETE api/<UnitController>/5
		[HttpDelete("{id}")]
		public ActionResult Delete(int id)
		{
			_UnitService.Delete(id);
			return Ok();
		}
	}
}
