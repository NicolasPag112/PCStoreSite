using System;

namespace PCStore.Models
{
    public class Usuario
    {
        public required int Id { get; set; }
        public required string Nome { get; set; }
        public required string Email  { get; set; }
        public required string Senha  { get; set; }
        public string CPF { get; set; }
    }
}