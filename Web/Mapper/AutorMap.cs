using AutoMapper;
using Domain;
using Web.Models.Autor;

namespace Web.Mapper
{
    public class AutorMap : Profile
    {
        public AutorMap()
        {
            CreateMap<Autor, AutorViewModel>();
        }
    }
}
