using EntityFrameworkRepository.Repository;
using EntityFrameworkRepository.Web.Extensions;
using Microsoft.EntityFrameworkCore;
using NLog;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

LogManager.LoadConfiguration(Environment.CurrentDirectory + Path.DirectorySeparatorChar + "nlog.config");

builder.Services.ConfigureLoggerService();

builder.Services.AddControllers();

builder.Services.Configure<RouteOptions>(options => options.LowercaseUrls = true);

builder.Services.ConfigureCors();

// Swagger
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

app.UseCors("CorsPolicy");

app.UseAuthorization();

app.MapControllers();

app.Run();