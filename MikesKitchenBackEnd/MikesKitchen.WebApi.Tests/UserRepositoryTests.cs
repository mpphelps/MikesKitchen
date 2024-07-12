using MikesKitchen.Common.DataContext.SqlServer.Repositories;
using MikesKitchen.Common.EntityModels.SqlServer;

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
			var result = repository.Create(user);

			// Assert
			Assert.AreEqual(user, result);
		}
	}
}