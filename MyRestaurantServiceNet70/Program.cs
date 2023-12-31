using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using MyRestaurantServiceNet70.Data;
using MyRestaurantServiceNet70;
var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<MyRestaurantServiceContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("MyRestaurantServiceContext") ?? throw new InvalidOperationException("Connection string 'MyRestaurantServiceContext' not found.")));

// Add services to the container.

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

app.MapContactEndpoints();

app.MapMenuItemEndpoints();

app.MapMenuItemOrderedEndpoints();

app.MapTogoOrderEndpoints();

app.Run();
