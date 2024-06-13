using Microsoft.AspNetCore.Mvc;
using MikesKitchen.Common;
using MikesKitchen.WebApi.Repositories;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MikesKitchen.WebApi.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class UserController : ControllerBase
	{
		private readonly IUserRepository _userRepository;

		public UserController(IUserRepository userRepository)
		{
			_userRepository = userRepository;
		}
		// GET: api/<UserController>
		[HttpGet]
		public IEnumerable<User> Get()
		{
			return _userRepository.GetAll();
		}

		// GET api/<UserController>/5
		[HttpGet("{id}")]
		public User Get(int id)
		{
			return _userRepository.Get(id);
		}

		// POST api/<UserController>
		[HttpPost]
		public void Post([FromBody] User user)
		{
			_userRepository.Create(user);
		}

		// PUT api/<UserController>/5
		[HttpPut("{id}")]
		public void Put(int id, [FromBody] string value)
		{
		}

		// DELETE api/<UserController>/5
		[HttpDelete("{id}")]
		public void Delete(int id)
		{
			_userRepository.Delete(id);
		}
	}
}
