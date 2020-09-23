using AutoMapper;
using Domain;
using Web.Models.Autor;
using Web.Models.Livro;

namespace Web.Mapper
{
    public class LivroMap : Profile
    {
        public LivroMap()
        {
            CreateMap<Livro, LivroViewModel>();
        }
    }
}
