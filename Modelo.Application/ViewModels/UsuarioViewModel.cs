﻿using System;
using System.ComponentModel.DataAnnotations;

namespace Modelo.Application.ViewModels
{
    public class UsuarioViewModel
    {
        [Required]
        public Guid Id { get; set; }
        [Required]
        public string Nome { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string Senha { get; set; }
    }
}
