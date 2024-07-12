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
		public IEnumerable<Unit> Get()
		{
			return _UnitService.GetAll();
		}

		// GET api/<UnitController>/5
		[HttpGet("{id}")]
		public Unit Get(int id)
		{
			return _UnitService.Get(id);
		}

		// POST api/<UnitController>
		[HttpPost]
		public void Post([FromBody] Unit Unit)
		{
			_UnitService.Create(Unit);
		}

		// PUT api/<UnitController>/5
		[HttpPut]
		public void Put([FromBody] Unit Unit)
		{
			_UnitService.Update(Unit);
		}

		// DELETE api/<UnitController>/5
		[HttpDelete("{id}")]
		public void Delete(int id)
		{
			_UnitService.Delete(id);
		}
	}
}
