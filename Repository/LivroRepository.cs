using Domain;
using Repository.Data;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace Repository
{
    public class LivroRepository
    {
        private WebApiContext Context { get; set; }

        public LivroRepository(WebApiContext context)
        {
            this.Context = context;
        }

        public List<Livro> GetAll()
        {
            return Context.Livros.ToList();

        }

        public Livro GetLivroById(int id)
        {
            return Context.Livros.FirstOrDefault(x => x.AutorId == id);
        }
        public List<Livro> GetLivrosById(int id)
        {
            var livro = Context.Livros.Where(x => x.AutorId == id);
            return livro.ToList();
        }

        public void Save(Livro livro)
        {
            this.Context.Livros.Add(livro);
            this.Context.SaveChanges();
        }

        public void Delete(int id)
        {
            var livro = Context.Livros.FirstOrDefault(x => x.Id == id);
            this.Context.Livros.Remove(livro);
            this.Context.SaveChanges();
        }

        public void Update(int id, Livro livro)
        {
            var livroOld = Context.Livros.FirstOrDefault(x => x.Id == id);
            livroOld.Titulo = livro.Titulo;
            livroOld.ISBN = livro.ISBN;
            livroOld.Ano = livro.Ano;

            Context.Livros.Update(livroOld);
            this.Context.SaveChanges();
        }
    }
}
