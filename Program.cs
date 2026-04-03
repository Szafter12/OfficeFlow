using System.Text.Json.Serialization;
using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.EntityFrameworkCore;
using OfficeFlow.Interfaces;
using OfficeFlow.Middlewares;
using OfficeFlow.Services;
using Serilog;

var builder = WebApplication.CreateBuilder(args);

// Loggger settings from appsettings.json
builder.Host.UseSerilog((ctx, lc) => lc.ReadFrom.Configuration(ctx.Configuration));

// Database connection
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

builder
    .Services.AddControllers()
    .AddJsonOptions(options =>
    {
        options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
    });
builder.Services.AddDbContext<ApplicationDbContext>(options => options.UseNpgsql(connectionString));

// Middlewares
builder.Services.AddTransient<GlobalExceptionMiddleware>();

// Validators
builder.Services.AddFluentValidationAutoValidation();
builder.Services.AddFluentValidationClientsideAdapters();
builder.Services.AddValidatorsFromAssemblyContaining<ReservationDtoValidator>();

// Services
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IOfficeService, OfficeService>();
builder.Services.AddScoped<IDeskService, DeskService>();
builder.Services.AddScoped<IAmenityService, AmenityService>();
builder.Services.AddScoped<IReservationService, ReservationService>();

var app = builder.Build();

app.UseMiddleware<GlobalExceptionMiddleware>();

app.MapControllers();
app.Run();
