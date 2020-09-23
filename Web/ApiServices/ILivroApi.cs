using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Web.Models.Livro;

namespace Web.ApiServices
{
    public interface ILivroApi
    {
        Task PostLivro(CriaLivroViewModel form);
        Task<List<LivroViewModel>> GetLivros();
        Task<LivroViewModel> GetLivro(int id);
    }
}
