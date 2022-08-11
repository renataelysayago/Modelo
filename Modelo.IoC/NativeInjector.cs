using Microsoft.Extensions.DependencyInjection;
using Modelo.Application.Interfaces;
using Modelo.Application.Services;
using Modelo.Data.Repositories;
using Modelo.Domain.Interfaces;

namespace Modelo.IoC
{
    public static class NativeInjector
    {
        public static void RegisterServices(IServiceCollection services)
        {
            #region Services

            services.AddScoped<IUsuarioService, UsuarioService>();

            #endregion

            #region Repositories

            services.AddScoped<IUsuarioRepository, UsuarioRepository>();

            #endregion
        }
    }
}