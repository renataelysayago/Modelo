﻿using Modelo.Application.ViewModels;

namespace Modelo.Application.ViewModels
{
    public class UserAuthenticateResponseViewModel
    {
        public UserAuthenticateResponseViewModel(UsuarioViewModel usuario, string token)
        {
            this.Usuario = usuario;
            this.Token = token;
        }

        public UsuarioViewModel Usuario { get; set; }
        public string Token { get; set; }
    }
}
