using Microsoft.EntityFrameworkCore;
using PeopleManagement.Api.Middlewares;
using PeopleManagement.Api.Services;
using PeopleManagement.Core.Interfaces;
using PeopleManagement.Infrastructure.Data;
using PeopleManagement.Infrastructure.Repositories;
using Serilog;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

builder.Services.AddDbContext<AppDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// DI
builder.Services.AddScoped<IPersonRepository, PersonRepository>();
builder.Services.AddScoped<IAddressRepository, AddressRepository>();
builder.Services.AddScoped<IPersonService, PersonService>();
builder.Services.AddScoped<IAddressService, AddressService>();

//swagger
builder.Services.AddSwaggerGen();

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAngular",
        policy =>
        {
            policy.WithOrigins("http://localhost:4200")
                  .AllowAnyHeader()
                  .AllowAnyMethod()
                  .AllowCredentials();
        });
});

Log.Logger = new LoggerConfiguration()
    .WriteTo.File("log.txt", rollingInterval: RollingInterval.Day)
    .CreateLogger();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.UseSwagger();
    app.UseSwaggerUI(config =>
    {
        config.SwaggerEndpoint("/swagger/v1/swagger.json", "People Management API v1");
        config.RoutePrefix = string.Empty; //to set swagger UI at root url
    });
    app.UseCors("AllowAngular");
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.UseMiddleware<ExceptionMiddleware>();
app.MapControllers();

app.Run();
