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

        public UsuarioViewModel GetById(string id)
        {
            if (!Guid.TryParse(id, out Guid userId))
                throw new Exception("O id do usuário não é válido");

            Usuario _user = this.usuarioRepository.Find(x => x.Id == userId && !x.IsDeleted);
            if (_user == null)
                throw new Exception("Usuário não encontrado");

            return mapper.Map<UsuarioViewModel>(_user);
        }

        public bool Put(UsuarioViewModel userViewModel)
        {
            if (userViewModel.Id == Guid.Empty)
                throw new Exception("O id é inválido");

            Usuario _user = this.usuarioRepository.Find(x => x.Id == userViewModel.Id && !x.IsDeleted);
            if (_user == null)
                throw new Exception("Usuário não encontrado");

            _user = mapper.Map<Usuario>(userViewModel);
            //_user.Password = EncryptPassword(_user.Password);

            this.usuarioRepository.Update(_user);

            return true;
        }

        public bool Delete(string id)
        {
            if (!Guid.TryParse(id, out Guid userId))
                throw new Exception("O id do usuário não é válido");

            Usuario _user = this.usuarioRepository.Find(x => x.Id == userId && !x.IsDeleted);
            if (_user == null)
                throw new Exception("Usuário não encontrado");

            return this.usuarioRepository.Delete(_user);
        }

        //public UserAuthenticateResponseViewModel Authenticate(UserAuthenticateRquestViewModel user)
        //{
        //    if (string.IsNullOrEmpty(user.Email) || string.IsNullOrEmpty(user.Password))
        //        throw new Exception("O Email/Senha deve ser informado");

        //    user.Password = EncryptPassword(user.Password);

        //    Usuario _user = this.usuarioRepository.Find(x => !x.IsDeleted && x.Email.ToLower() == user.Email.ToLower()
        //                                                            && x.Password.ToLower() == user.Password.ToLower());

        //    if (_user == null)
        //        throw new Exception("Usuário não encontrado");

        //    return new UserAuthenticateResponseViewModel(mapper.Map<UserViewModel>(_user), TokenService.GenerateToken(_user));
        //}

        //private string EncryptPassword(string password)
        //{
        //    HashAlgorithm sha = new SHA1CryptoServiceProvider();

        //    byte[] encryptedPassword = sha.ComputeHash(Encoding.UTF8.GetBytes(password));

        //    StringBuilder stringBuilder = new StringBuilder();
        //    foreach (var caracter in encryptedPassword)
        //    {
        //        stringBuilder.Append(caracter.ToString("X2"));
        //    }

        //    return stringBuilder.ToString();
        //}
    }
}
