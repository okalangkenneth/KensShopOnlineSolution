using KensShopOnline.Api.Data;
using KensShopOnline.Api.Repositories.Contracts;
using KensShopOnline.Api.Repositories;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//***IMPORTANT INSTRUCTION HERE - MUST CONFIGURE CONNECTION BEFORE RUNNING MIGRATIONS
builder.Services.AddDbContextPool<KensShopOnlineDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("KensShopOnlineConnection"))
);
builder.Services.AddScoped<IProductRepository, ProductRepository>();
//builder.Services.AddScoped<IShoppingCartRepository, ShoppingCartRepository>();



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
