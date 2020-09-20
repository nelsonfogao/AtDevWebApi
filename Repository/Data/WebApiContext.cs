using Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Logging;
using Repository.Mapping;
using System;
using System.Collections.Generic;
using System.Text;

namespace Repository.Data
{
    public class WebApiContext : DbContext
    {
        public DbSet<Autor> Autores { get; set; }
        public DbSet<Livro> Livros { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }


        public static readonly ILoggerFactory loggerFactory = LoggerFactory.Create(b => { b.AddConsole(); });

        public WebApiContext(DbContextOptions<WebApiContext> options) : base(options)
        {

        }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseLoggerFactory(loggerFactory);

            base.OnConfiguring(optionsBuilder);
        }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new UsuarioMap());
            modelBuilder.ApplyConfiguration(new AutorMap());
            modelBuilder.ApplyConfiguration(new LivroMap());

            base.OnModelCreating(modelBuilder);
        }

        public class RedeSocialContextFactory : IDesignTimeDbContextFactory<WebApiContext>
        {
            public WebApiContext CreateDbContext(string[] args)
            {
                var optionsBuilder = new DbContextOptionsBuilder<WebApiContext>();
                optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=AtLivros;Trusted_Connection=True;MultipleActiveResultSets=true");

                return new WebApiContext(optionsBuilder.Options);

            }
        }
    }
}
