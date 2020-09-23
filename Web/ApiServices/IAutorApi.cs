using ApplicationService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Web.Models.Autor;

namespace Web.ApiServices
{
    public interface IAutorApi
    {
        Task<List<AutorViewModel>> GetAutors();
        Task<AutorViewModel> GetAutor(int id);
    }
}
