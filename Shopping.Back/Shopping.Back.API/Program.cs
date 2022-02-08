using AutoMapper;
using FluentValidation.AspNetCore;
using Microsoft.EntityFrameworkCore;
using Shopping.API.Interfaces.Repository;
using Shopping.API.Model.Context;
using Shopping.Back.API.Config;
using Shopping.Back.API.Filters;
using Shopping.Back.API.Repository;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// SQL Connection
var conn = builder.Configuration["ConnectionStrings:SQL_Shopping"];
builder.Services.AddDbContext<SQLContext>(options => options.UseSqlServer(conn));

// AutoMapper
IMapper mapper = MappingConfig.RegisterMaps().CreateMapper();
builder.Services.AddSingleton(mapper);
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

// Dependencies
builder.Services.AddScoped<IProductRepository, ProductRepository>();

// Fluent Validation
builder.Services
    .AddMvc(options => options.Filters.Add(typeof(ModelStateValidatorFilter)))
    .AddFluentValidation(config => config.RegisterValidatorsFromAssembly(Assembly.GetExecutingAssembly()));

// Others
builder.Services
    .AddControllers()
    .ConfigureApiBehaviorOptions(options => { options.SuppressModelStateInvalidFilter = true; })
    .AddNewtonsoftJson(options => options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore);
    
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
