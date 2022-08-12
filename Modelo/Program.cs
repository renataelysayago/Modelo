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

// Configure the HTTP request pipeline.
//if (!app.Environment.IsDevelopment())
//{
//    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
//    //app.UseHsts();
//}

app.UsePathBase("/api");

app.UseSwaggerConfiguration();

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
