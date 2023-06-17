using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Biblioteca.Models
{
    public class ReservaModel
    {

        [Key]
        public int Id { get; set; }
        public DateTime Data { get; set; }

        public bool Devolvido { get; set; }

        public int LivroId { get; set; }

        public LivroModel Livro { get; set; } = null!;
    }
}
