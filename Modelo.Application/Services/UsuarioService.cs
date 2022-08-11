using AutoMapper;
using Modelo.Application.Interfaces;
using Modelo.Application.ViewModels;
using Modelo.Domain.Entities;
using Modelo.Domain.Interfaces;

namespace Modelo.Application.Services
{
    public class UsuarioService : IUsuarioService
    {
        private readonly IUsuarioRepository usuarioRepository;
        private readonly IMapper mapper;

        public UsuarioService(IUsuarioRepository usuarioRepository, IMapper mapper)
        {
            this.usuarioRepository = usuarioRepository;
            this.mapper = mapper;
        }

        public List<UsuarioViewModel> Get()
        {
            IEnumerable<Usuario> _users = this.usuarioRepository.GetAll();

            List<UsuarioViewModel> _usuarioViewModels = mapper.Map<List<UsuarioViewModel>>(_users);

            return _usuarioViewModels;
        }

        public bool Post(UsuarioViewModel usuarioViewModel)
        {
            if (usuarioViewModel.Id != Guid.Empty)
                throw new Exception("O id do usuário precisa ser vazio");

            //Validator.ValidateObject(usuarioViewModel, new ValidationContext(userViewModel), true);

            Usuario _usuario = mapper.Map<Usuario>(usuarioViewModel);
            //_usuario.Password = EncryptPassword(_usuario.Password);

            this.usuarioRepository.Create(_usuario);
            return true;
        }
    }
}
