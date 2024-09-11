using Core.Interfaces;
using Core.MapperProfiles;
using Core.Services;
using Data;
using FluentValidation.AspNetCore;
using FluentValidation;
using Microsoft.EntityFrameworkCore;
using System.Text.Json.Serialization;
using WebApiServer_PD211.Middlewares;

var builder = WebApplication.CreateBuilder(args);
string connectionString = builder.Configuration.GetConnectionString("LocalDb")!;

// Add services to the container.

builder.Services.AddControllers()
    .AddJsonOptions(options =>
    {
        //options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.Preserve;
        //options.JsonSerializerOptions.MaxDepth = 0;
    });
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<ShopDbContext>(opt => opt.UseSqlServer(connectionString));

// --------------- configure Fluent Validators
builder.Services.AddFluentValidationAutoValidation();
// enable client-side validation
builder.Services.AddFluentValidationClientsideAdapters();
// Load an assembly reference rather than using a marker type.
builder.Services.AddValidatorsFromAssemblies(AppDomain.CurrentDomain.GetAssemblies());

// --------------- configure Auto Mapper
builder.Services.AddAutoMapper(typeof(AppProfile));

builder.Services.AddScoped<IProductsService, ProductsService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseMiddleware<ErrorHandlerMiddleware>();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
    