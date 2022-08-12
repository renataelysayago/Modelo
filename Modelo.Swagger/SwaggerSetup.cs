using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;

namespace Modelo.Swagger
{
    public static class SwaggerSetup
    {
        public static IServiceCollection AddSwaggerConfiguration(this IServiceCollection services)
        {
            return services.AddSwaggerGen(opt =>
            {
                opt.SwaggerDoc("v1", new OpenApiInfo { Title = "Modelo", Version = "v1" });
            });
        }

        public static IApplicationBuilder UseSwaggerConfiguration(this IApplicationBuilder app)
        {
            return app.UseSwagger().UseSwaggerUI(c =>
            {
                c.RoutePrefix = String.Empty;
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "API v1");
            });
        }
    }
}