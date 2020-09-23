using Domain;
using Repository;
using System;
using System.Collections.Generic;

namespace ApplicationService
{
    public class LivroServices
    {
        private LivroRepository Repository { get; set; }

        public LivroServices(LivroRepository repository)
        {
            this.Repository = repository;
        }

        public List<Livro> GetAll()
        {
            return Repository.GetAll();
        }

        public Livro GetLivroById(int id)
        {
            return Repository.GetLivroById(id);
        }
        public List<Livro> GetLivrosById(int id)
        {
            return Repository.GetLivrosById(id);
        }

        public void Save(Livro livro)
        {

            this.Repository.Save(livro);
        }

        public void Delete(int id)
        {
            Repository.Delete(id);
        }

        public void Update(int id, Livro livro)
        {
            Repository.Update(id, livro);
        }

    }
}
