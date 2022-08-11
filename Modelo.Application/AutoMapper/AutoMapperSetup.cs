using AutoMapper;
using Modelo.Application.ViewModels;
using Modelo.Domain.Entities;

namespace Modelo.Application.AutoMapper
{
    public class AutoMapperSetup : Profile
    {
        public AutoMapperSetup()
        {
            #region ViewModelToDomain

            CreateMap<UsuarioViewModel, Usuario>();

            #endregion

            #region DomainToViewModel

            CreateMap<Usuario, UsuarioViewModel>();

            #endregion
        }

    }
}
