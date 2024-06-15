using Microsoft.EntityFrameworkCore;
using MikesKitchen.Common;
using MikesKitchen.Common.Core.Interfaces;
using MikesKitchen.Common.Core.Services;
using MikesKitchen.Common.DataContext.SqlServer.Interfaces;
using MikesKitchen.Common.DataContext.SqlServer.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Register the repository
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IUserService, UserService>();

builder.Services.AddControllers();
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

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
