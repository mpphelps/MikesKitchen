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
		public IEnumerable<User> Get()
		{
			return _userService.GetAll();
		}

		// GET api/<UserController>/5
		[HttpGet("{id}")]
		public User Get(int id)
		{
			return _userService.Get(id);
		}

		// POST api/<UserController>
		[HttpPost]
		public void Post([FromBody] User user)
		{
			_userService.Create(user);
		}

		// PUT api/<UserController>/5
		[HttpPut]
		public void Put([FromBody] User user)
		{
			_userService.Update(user);
		}

		// DELETE api/<UserController>/5
		[HttpDelete("{id}")]
		public void Delete(int id)
		{
			_userService.Delete(id);
		}
	}
}
