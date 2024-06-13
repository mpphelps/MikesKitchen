using Microsoft.EntityFrameworkCore;
using MikesKitchen.Common;
using MikesKitchen.WebApi.Repositories;
using Moq;
using System.Collections.Generic;

namespace MikesKitchen.WebApi.Tests
{
	[TestClass]
	public class UserRepositoryTests
	{
		private UserRepository repository;

		[TestInitialize]
		public void Initialize()
		{
			repository = new UserRepository();
		}

		// Todo, we should be ensuring delete & ensuring create DB for every test run.  
		// How do we do this and preserve our test db data?
		[TestMethod]
		public async Task CreateAsync_ShouldAddTestUser()
		{
			// Arrange
			var user = new User
			{
				Email = "test@test.com",
				UserName = "Test",
				FirstName = "Testfirstname",
				LastName = "Testlastname",
				Password = "Password"
			};

			// Act
			var result = await repository.CreateAsync(user);

			// Assert
			Assert.AreEqual(user, result);
		}
	}
}