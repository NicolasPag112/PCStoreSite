using System;

namespace PCStore.Models.ViewModels
{
    public class UsuarioLogin
    {
        public required string Email  { get; set; }
        public required string Senha  { get; set; }
    }
}