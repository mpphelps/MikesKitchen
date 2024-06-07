using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MikesKitchen.Common.DataContext.SqlServer
{
	public static class MikesKitchenContextExtensions
	{
		public static IServiceCollection AddMikesKitchenContext(
			this IServiceCollection services, string connectionString =
			"Data Source=.;Initial Catalog=MikesKitchen;"
			+ "Integrated Security=true;MultipleActiveResultsets=true;"
			+ "Encrypt=false")
		{
			services.AddDbContext<MikesKitchenContext>(options => options.UseSqlServer(connectionString));
			return services;
		}
	}
}
