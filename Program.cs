using System.Text.Json.Serialization;
using Microsoft.EntityFrameworkCore;
using OfficeFlow.Interfaces;
using OfficeFlow.Middlewares;
using OfficeFlow.Services;

var builder = WebApplication.CreateBuilder(args);

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

builder
    .Services.AddControllers()
    .AddJsonOptions(options =>
    {
        options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
    });
builder.Services.AddDbContext<ApplicationDbContext>(options => options.UseNpgsql(connectionString));
builder.Services.AddTransient<GlobalExceptionMiddleware>();
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IOfficeService, OfficeService>();
builder.Services.AddScoped<IDeskService, DeskService>();
builder.Services.AddScoped<IAmenityService, AmenityService>();
builder.Services.AddScoped<IReservationService, ReservationService>();

var app = builder.Build();

app.UseMiddleware<GlobalExceptionMiddleware>();

app.MapControllers();
app.Run();
