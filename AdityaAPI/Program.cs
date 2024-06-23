using AdityaAPI.Models;
using AdityaAPI.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//Custome Add below
//builder.Services.AddScoped<IRepository<City>,Repository<T>();
//builder.Services.AddScoped(typeof(IRepository), typeof(Repository));
builder.Services.AddSingleton<IRepository<City>, Repository<City>>();

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
