using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Web.Models.Autor;

namespace Web.Models.Livro
{
    public class CriaLivroViewModel
    {

        [Required(ErrorMessage = "Campo Título é obrigatório")]

        public string Titulo { get; set; }
        [Required(ErrorMessage = "Campo ISBN é obrigatório")]
        public string ISBN { get; set; }
        [Required(ErrorMessage = "Campo Ano é obrigatório")]
        public int Ano { get; set; }
        [Required(ErrorMessage = "Campo Autor é obrigatório")]
        public List<AutorViewModel> Autors { get; set; }

        public int AutorId { get; set; }
    }
}
