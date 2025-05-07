using Microsoft.EntityFrameworkCore;
using Online_food_delivery_system.Interface;
using Online_food_delivery_system.Models;
using Online_food_delivery_system.Repository;
using Online_food_delivery_system.Service;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<FoodDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("cstring")));
builder.Services.AddScoped<IPayment, PaymentRepository>();
builder.Services.AddScoped<IOrder, OrderRepository>();
builder.Services.AddScoped<IMenuItem, MenuItemRepository>();
builder.Services.AddScoped<IRestaurant, RestaurantRepository>();
builder.Services.AddScoped<ICustomer, CustomerRepository>();
builder.Services.AddScoped<PaymentService>();
builder.Services.AddScoped<CustomerService>();
builder.Services.AddScoped<RestaurantService>();
builder.Services.AddScoped<MenuItemService>();
builder.Services.AddScoped<OrderService>();
builder.Services.AddScoped<IDelivery, DeliveryRepository>();
builder.Services.AddScoped<IAgent, AgentRepository>();
builder.Services.AddScoped<DeliveryService>();
builder.Services.AddScoped<AgentService>();

builder.Services.AddControllers().AddNewtonsoftJson(options =>
{
    options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore;
});//cyclic error

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
