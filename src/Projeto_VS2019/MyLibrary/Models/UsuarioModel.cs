using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MyLibrary.Models
{
    public class UsuarioModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage ="Digite o Nome")]
        public string Nome { get; set;}
        [Required(ErrorMessage = "Digite o Email")]
        [EmailAddress(ErrorMessage ="Email informado não é valido!")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Digite a senha")]
        public string Senha { get; set; }

    }
}
