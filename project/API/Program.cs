using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using project.API.Data;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<projectContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("projectContext") ?? throw new InvalidOperationException("Connection string 'projectContext' not found.")));

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddControllersWithViews();

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

var crudApi = app.MapGroup("/api/inventory");

app.UseDefaultFiles();

app.UseStaticFiles();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
