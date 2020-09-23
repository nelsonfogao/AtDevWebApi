using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Domain;
using Repository.Data;
using Web.Models.Livro;
using Web.Models.Autor;
using Web.ApiServices;
using Microsoft.AspNetCore.Http;
using RestSharp;
using Newtonsoft.Json;
using ApplicationService;
using AutoMapper;

namespace Web.Controllers
{
    public class LivrosController : Controller
    {
        private readonly ILivroApi livroApi;
        private readonly IAutorApi autorApi;
        private readonly LivroServices LivroServices;
        private readonly AutorServices AutorServices;
        private readonly IMapper mapper;
        private readonly WebApiContext _context;


        public LivrosController(ILivroApi livroApi, IAutorApi autorApi, LivroServices livroServices, AutorServices autorServices, IMapper mapper, WebApiContext context)
        {
            this.livroApi = livroApi;
            this.autorApi = autorApi;
            this.LivroServices = livroServices;
            this.AutorServices = autorServices;
            this.mapper = mapper;
            this._context = context;
        }

        // GET: Livros
        public ActionResult Index()
        {
            var client = new RestClient();

            var requestToken = new RestRequest("https://localhost:5001/api/usuarios/token");

            requestToken.AddJsonBody(JsonConvert.SerializeObject(new
            {
                Login = "Nelson",
                Password = "abc123"
            }));


            var result = client.Post<TokenResult>(requestToken).Data;

            this.HttpContext.Session.SetString("Token", result.Token);

            var request = new RestRequest("https://localhost:5001/api/livros", DataFormat.Json);
            request.AddHeader("Authorization", "Bearer " + this.HttpContext.Session.GetString("Token"));

            var response = client.Get<List<LivroViewModel>>(request);

            return View(response.Data);
        }

        // GET: Livros/Details/5
        public ActionResult Details(int id)
        {
            var client = new RestClient();
            var request = new RestRequest("https://localhost:5001/api/livros/" + id, DataFormat.Json);
            request.AddHeader("Authorization", "Bearer " + this.HttpContext.Session.GetString("Token"));

            var response = client.Get<LivroViewModel>(request);

            var livro = response.Data;
            var idAutor = livro.AutorId;
            var autor = AutorServices.GetAutorById(idAutor);
            livro.Autor = mapper.Map<AutorViewModel>(autor);
            return View(livro);

        }

        // GET: Livros/Create
        public ActionResult Create()
        {
            var viewModel = new CriaLivroViewModel();


            var client = new RestClient();

            var request = new RestRequest("https://localhost:5001/api/autors", DataFormat.Json);
            request.AddHeader("Authorization", "Bearer " + this.HttpContext.Session.GetString("Token"));

            var response = client.Get<List<AutorViewModel>>(request);

            var list = response.Data;
            viewModel.Autors = mapper.Map<List<AutorViewModel>>(list);

            return View(viewModel);
        }

        // POST: PessoaController/Create

        // POST: Livros/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Titulo,ISBN,Ano,AutorId")] Livro livro)
        {
            if (ModelState.IsValid)
            {
                _context.Add(livro);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(livro);
        }
        public ActionResult Edit(int id)
        {
            var client = new RestClient();
            var request = new RestRequest("https://localhost:5001/api/livros/" + id, DataFormat.Json);
            request.AddHeader("Authorization", "Bearer " + this.HttpContext.Session.GetString("Token"));

            var response1 = client.Get<LivroViewModel>(request);

            return View(response1.Data);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Titulo,ISBN,Ano,AutorId")] Livro livro)
        {
            if (id != livro.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(livro);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!LivroExists(livro.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(livro);
        }
        public ActionResult Delete(int? id)
        {
            var client = new RestClient();
            var request = new RestRequest("https://localhost:5001/api/livros/" + id, DataFormat.Json);
            request.AddHeader("Authorization", "Bearer " + this.HttpContext.Session.GetString("Token"));

            var response1 = client.Get<LivroViewModel>(request);

            return View(response1.Data);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var livro = await _context.Livros.FindAsync(id);
            _context.Livros.Remove(livro);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        private bool LivroExists(int id)
        {
            return _context.Livros.Any(e => e.Id == id);
        }


    }

}
