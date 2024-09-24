using Amazon.Util.Internal.PlatformServices;
using Application.Interfaces;
using Application.Services;
using Infraestructure.Data.DbContext;
using Infraestructure.Data.Models;
using Infraestructure.Data.Repositories;
using Infraestructure.Data.Repositories.Interfaces;
using Infraestructure.Services;
using Infraestructure.Services.Interfaces;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


builder.Services.AddScoped<DbContextMongoDB>();

builder.Services.AddScoped<IPostService, PostService>();
builder.Services.AddScoped<IAppSettingsService, AppSettingsService>();

builder.Services.AddScoped<IRepository<Post>, Repository<Post>>();

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
