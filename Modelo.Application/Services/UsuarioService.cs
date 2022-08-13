using AutoMapper;
using Modelo.Application.Interfaces;
using Modelo.Application.ViewModels;
using Modelo.Auth.Services;
using Modelo.Domain.Entities;
using Modelo.Domain.Interfaces;
using System.ComponentModel.DataAnnotations;
using System.Security.Cryptography;
using System.Text;

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

        public bool CriarUsuario(UsuarioViewModel usuarioViewModel)
        {
            if (usuarioViewModel.Id != Guid.Empty)
                throw new Exception("O id do usuário precisa ser vazio");

            Validator.ValidateObject(usuarioViewModel, new ValidationContext(usuarioViewModel), true);

            Usuario _usuario = mapper.Map<Usuario>(usuarioViewModel);
            _usuario.Senha = EncryptPassword(_usuario.Senha);

            this.usuarioRepository.Create(_usuario);
            return true;
        }

        public UsuarioViewModel GetById(string id)
        {
            if (!Guid.TryParse(id, out Guid userId))
                throw new Exception("O id do usuário não é válido");

            Usuario _usuario = this.usuarioRepository.Find(x => x.Id == userId && !x.IsDeleted);
            if (_usuario == null)
                throw new Exception("Usuário não encontrado");

            return mapper.Map<UsuarioViewModel>(_usuario);
        }

        public bool Put(UsuarioViewModel userViewModel)
        {
            if (userViewModel.Id == Guid.Empty)
                throw new Exception("O id é inválido");

            Usuario _usuario = this.usuarioRepository.Find(x => x.Id == userViewModel.Id && !x.IsDeleted);
            if (_usuario == null)
                throw new Exception("Usuário não encontrado");

            _usuario = mapper.Map<Usuario>(userViewModel);
            _usuario.Senha = EncryptPassword(_usuario.Senha);

            this.usuarioRepository.Update(_usuario);

            return true;
        }

        public bool Delete(string id)
        {
            if (!Guid.TryParse(id, out Guid userId))
                throw new Exception("O id do usuário não é válido");

            Usuario _usuario = this.usuarioRepository.Find(x => x.Id == userId && !x.IsDeleted);
            if (_usuario == null)
                throw new Exception("Usuário não encontrado");

            return this.usuarioRepository.Delete(_usuario);
        }

        public UserAuthenticateResponseViewModel Authenticate(UserAuthenticateRquestViewModel usuario)
        {
            if (string.IsNullOrEmpty(usuario.Email) || string.IsNullOrEmpty(usuario.Senha))
                throw new Exception("O Email/Senha deve ser informado");

            usuario.Senha = EncryptPassword(usuario.Senha);

            Usuario _user = this.usuarioRepository.Find(x => !x.IsDeleted && x.Email.ToLower() == usuario.Email.ToLower()  && x.Senha.ToLower() == usuario.Senha.ToLower());

            if (_user == null)
                throw new Exception("Usuário não encontrado");

            return new UserAuthenticateResponseViewModel(mapper.Map<UsuarioViewModel>(_user), TokenService.GenerateToken(_user));
        }

        private string EncryptPassword(string senha)
        {
            HashAlgorithm sha = new SHA1CryptoServiceProvider();

            byte[] encryptedPassword = sha.ComputeHash(Encoding.UTF8.GetBytes(senha));

            StringBuilder stringBuilder = new StringBuilder();
            foreach (var caracter in encryptedPassword)
            {
                stringBuilder.Append(caracter.ToString("X2"));
            }

            return stringBuilder.ToString();
        }
    }
}
