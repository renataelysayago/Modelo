using Microsoft.EntityFrameworkCore;
using Modelo.Application.AutoMapper;
using Modelo.Data.Context;
using Modelo.IoC;
using Modelo.Swagger;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllersWithViews();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerConfiguration();
builder.Services.AddControllers();

builder.Services.AddDbContext<ModeloContext>(options => {
    options.UseSqlServer(builder.Configuration.GetConnectionString("ModeloDB")).EnableSensitiveDataLogging();
    });

//IoC
NativeInjector.RegisterServices(builder.Services);

//AutoMapper
builder.Services.AddAutoMapper(typeof(AutoMapperSetup));

var app = builder.Build();

app.UsePathBase("/api");

if (app.Environment.IsDevelopment())
{
    app.UseSwaggerConfiguration();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller}/{action=Index}/{id?}");

app.MapFallbackToFile("index.html"); ;

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
