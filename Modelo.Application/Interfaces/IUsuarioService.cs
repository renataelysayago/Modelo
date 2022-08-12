using Modelo.Application.ViewModels;

namespace Modelo.Application.Interfaces
{
    public interface IUsuarioService
    {
        List<UsuarioViewModel> Get();
        bool Post(UsuarioViewModel usuarioViewModel);
        UsuarioViewModel GetById(string id);
        bool Put(UsuarioViewModel userViewModel);
        bool Delete(string id);
        //UserAuthenticateResponseViewModel Authenticate(UserAuthenticateRquestViewModel user);
    }
}
