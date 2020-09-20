using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Web.Models.Autor;

namespace Web.Models.Livro
{
    public class CriaLivroViewModel
    {
        public string Titulo { get; set; }
        public string ISBN { get; set; }
        public int Ano { get; set; }
        public List<AutorViewModel> Autors { get; set; }

        public int AutorId { get; set; }
    }
}
