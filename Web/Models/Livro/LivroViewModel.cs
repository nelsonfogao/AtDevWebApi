using System.ComponentModel.DataAnnotations;
using Web.Models.Autor;

namespace Web.Models.Livro
{
    public class LivroViewModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Campo Título é obrigatório")]

        public string Titulo { get; set; }
        [Required(ErrorMessage = "Campo ISBN é obrigatório")]
        public string ISBN { get; set; }
        [Required(ErrorMessage = "Campo Ano é obrigatório")]
        public int Ano { get; set; }
        [Required(ErrorMessage = "Campo Autor é obrigatório")]
        public AutorViewModel Autor { get; set; }

        public int AutorId { get; set; }
    }
}
