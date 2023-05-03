using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Biblioteca.Models
{
    public class UsuarioModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Digite o nome do usuário")]
        public string Nome { get; set; }
        [Required(ErrorMessage = "Digite o Login do usuário")]
        public string Login { get; set; }
        [Required(ErrorMessage = "Digite o Email do usuário")]
        [EmailAddress(ErrorMessage = "O Email informado não é valido")]
        public string Email { get; set; }
        public string Senha { get; set; }
        public bool SenhaValida(string senha)
        {
            return Senha == senha;
        }
     }
}
