using Microsoft.EntityFrameworkCore;
using NLog.Web;
using Repositories;
using Repository;
using Services;
using ex02.MiddleWare;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

// Configure the HTTP request pipeline.



builder.Services.AddScoped<IUserRepository, UserRepository>();

builder.Services.AddScoped<IUserService, UserService>();

builder.Services.AddScoped<IProductRepository, ProductRepository>();

builder.Services.AddScoped<IProductService, ProductService>();

builder.Services.AddScoped<IOrderRepository, OrderRepository>();

builder.Services.AddScoped<IOrderService, OrderService>();

builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();

builder.Services.AddScoped<ICategoryService, CategoryService>();

builder.Services.AddTransient<IRatingRepository, RatingRepository>();


builder.Services.AddDbContext<AdoNet1Context>();

builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen();



builder.Services.AddDbContext<AdoNet1Context>(option => option.UseSqlServer(builder.Configuration.GetConnectionString("School")));

builder.Host.UseNLog();



var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}



app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.UseMiddleware();

app.UseStaticFiles();

app.Run();
