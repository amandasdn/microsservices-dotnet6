using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Shopping.API.Interfaces.Repository;
using Shopping.API.Model.Context;
using Shopping.Back.API.Config;
using Shopping.Back.API.Repository;

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

// Others
builder.Services.AddControllers().AddNewtonsoftJson(options =>
    options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
);
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
