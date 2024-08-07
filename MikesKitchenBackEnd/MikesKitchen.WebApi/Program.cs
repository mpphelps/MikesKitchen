using Microsoft.EntityFrameworkCore;
using MikesKitchen.Common;
using MikesKitchen.Common.Core.Interfaces;
using MikesKitchen.Common.Core.Services;
using MikesKitchen.Common.DataContext.SqlServer.Interfaces;
using MikesKitchen.Common.DataContext.SqlServer.Repositories;
using System.Text.Json.Serialization;

var myAllowSpecificOrigins = "_myAllowSpecificOrigins";

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddCors(options =>
{
	options.AddPolicy(name: myAllowSpecificOrigins,
		policy =>
		{
			policy.WithOrigins("http://localhost:5173")
						   .AllowAnyHeader()
						   .AllowAnyMethod();
		});
});

// Register the repository
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IUnitRepository, UnitRepository>();
builder.Services.AddScoped<IUnitService, UnitService>();
builder.Services.AddScoped<IRecipeRepository, RecipeRepository>();
builder.Services.AddScoped<IRecipeService, RecipeService>();

builder.Services.AddControllers().AddJsonOptions(options => {
	options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
	}
);
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
	app.UseSwagger();
	app.UseSwaggerUI();
}

app.UseCors(myAllowSpecificOrigins);

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
