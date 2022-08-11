using Modelo.Application.ViewModels;

namespace Modelo.Application.Interfaces
{
    public interface IUsuarioService
    {
        List<UsuarioViewModel> Get();
        bool Post(UsuarioViewModel usuarioViewModel);
    }
}
