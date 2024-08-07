using Microsoft.AspNetCore.Mvc;
using MikesKitchen.Common.Core.Interfaces;
using MikesKitchen.Common.EntityModels.SqlServer;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

// Controller: Handles input of the json object and returning action result
// Service: Handles logging and validating input object, any other business logic
// Repository: Handles the linq query to the DB
namespace MikesKitchen.WebApi.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class UserController : ControllerBase
	{
		private readonly IUserService _userService;

		public UserController(IUserService userService)
		{
			_userService = userService;
		}
		// GET: api/<UserController>
		[HttpGet]
		public ActionResult<List<User>> Get()
		{
			var users = _userService.GetAll();
			return Ok(users);
		}

		// GET api/<UserController>/5
		[HttpGet("{id}")]
		public ActionResult<User> Get(int id)
		{
			var user = _userService.Get(id);
			return Ok(user);
		}

		// POST api/<UserController>
		[HttpPost]
		public ActionResult Post([FromBody] User user)
		{
			_userService.Create(user);
			return Ok();
		}

		// PUT api/<UserController>/5
		[HttpPut]
		public ActionResult Put([FromBody] User user)
		{
			_userService.Update(user);
			return Ok();
		}

		// DELETE api/<UserController>/5
		[HttpDelete("{id}")]
		public ActionResult Delete(int id)
		{
			_userService.Delete(id);
			return Ok();
		}
	}
}
