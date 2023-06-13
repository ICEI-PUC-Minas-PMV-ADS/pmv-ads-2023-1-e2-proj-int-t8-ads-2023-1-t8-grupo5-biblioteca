using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Biblioteca.Models
{
    public class LivroModel
    {
        [Key]
        public int Id { get; set; }
        public string Titulo { get; set; }

        public string Autor { get; set; }

        public string Categoria { get; set; }

    }
}
