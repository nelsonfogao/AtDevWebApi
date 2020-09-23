using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Domain
{
    public class Autor
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Campo Nome é obrigatório")]

        public string Nome { get; set; }
        [Required(ErrorMessage = "Campo Sobrenome é obrigatório")]

        public string Sobrenome { get; set; }
        [Required(ErrorMessage = "Campo Email é obrigatório")]

        public string Email { get; set; }

        [Required(ErrorMessage = "Campo Data de nascimento é obrigatório")]

        public DateTime DataDeNascimento { get; set; }
        public virtual IList<Livro> Livros { get; set; }
    }
}
