using Domain;
using Repository.Data;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace Repository
{
    public class AutorRepository
    {
        private WebApiContext Context { get; set; }

        public AutorRepository(WebApiContext context)
        {
            this.Context = context;
        }

        public List<Autor> GetAll()
        {
            return Context.Autores.ToList();

        }

        public Autor GetAutorById(int id)
        {
            return Context.Autores.FirstOrDefault(x => x.Id == id);
        }

        public void Save(Autor autor)
        {
            this.Context.Autores.Add(autor);
            this.Context.SaveChanges();
        }

        public void Delete(int id)
        {
            var autor = Context.Autores.FirstOrDefault(x => x.Id == id);
            this.Context.Autores.Remove(autor);
            this.Context.SaveChanges();
        }

        public void Update(int id, Autor autor)
        {
            var autorOld = Context.Autores.FirstOrDefault(x => x.Id == id);
            autorOld.Nome = autor.Nome;
            autorOld.Sobrenome = autor.Sobrenome;
            autorOld.Email = autor.Email;
            autorOld.DataDeNascimento = autor.DataDeNascimento;

            Context.Autores.Update(autorOld);
            this.Context.SaveChanges();
        }
    }
}
