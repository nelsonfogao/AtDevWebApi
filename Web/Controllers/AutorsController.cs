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
using RestSharp;
using Newtonsoft.Json;
using Microsoft.AspNetCore.Http;
using Web.Models.Autor;
using ApplicationService;
using AutoMapper;
using Web.Models;

namespace Web.Controllers
{
    public class AutorsController : Controller
    {
        private AutorServices AutorServices { get; set; }
        private LivroServices LivroServices { get; set; }
        private readonly IMapper mapper;
        private readonly WebApiContext _context;

        public AutorsController(WebApiContext context, IMapper mapper, AutorServices autorServices, LivroServices livroServices)
        {
            this.AutorServices = autorServices;
            this.LivroServices = livroServices;
            this.mapper = mapper;
            _context = context;
        }

        // GET: Autors
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

            var request = new RestRequest("https://localhost:5001/api/autors", DataFormat.Json);
            request.AddHeader("Authorization", "Bearer " + this.HttpContext.Session.GetString("Token"));

            var response = client.Get<List<AutorViewModel>>(request);

            return View(response.Data);
        }
        public ActionResult GetAutors()
        {
            var client = new RestClient();

            var request = new RestRequest("https://localhost:5001/api/autors", DataFormat.Json);
            request.AddHeader("Authorization", "Bearer " + this.HttpContext.Session.GetString("Token"));

            var response = client.Get<List<AutorViewModel>>(request);

            return View(response.Data);
        }
        public ActionResult GetAutor(int id)
        {
            var client = new RestClient();

            var request = new RestRequest("https://localhost:5001/api/autors" + id, DataFormat.Json);
            request.AddHeader("Authorization", "Bearer " + this.HttpContext.Session.GetString("Token"));

            var response = client.Get<AutorViewModel>(request);

            return View(response.Data);
        }
        // GET: Autors/Details/5
        public ActionResult Details(int id)
        {
            var client = new RestClient();
            var request = new RestRequest("https://localhost:5001/api/autors/" + id, DataFormat.Json);
            request.AddHeader("Authorization", "Bearer " + this.HttpContext.Session.GetString("Token"));

            var response = client.Get<AutorViewModel>(request);

            return View(response.Data);
        }

        // GET: Autors/Create

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nome,Sobrenome,Email,DataDeNascimento")] Autor autor)
        {
            try
            {
                if (ModelState.IsValid == false)
                    return View(autor);


                var client = new RestClient();
                var request = new RestRequest("https://localhost:5001/api/autors", DataFormat.Json);
                request.AddJsonBody(autor);

                var response = client.Post<AutorViewModel>(request);
                _context.Add(autor);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            catch (System.Exception ex)
            {
                ModelState.AddModelError("APP_ERROR", ex.Message);
                return View(autor);
            }
        }

        public ActionResult Edit(int id)
        {
            var client = new RestClient();
            var request = new RestRequest("https://localhost:5001/api/autors/" + id, DataFormat.Json);
            request.AddHeader("Authorization", "Bearer " + this.HttpContext.Session.GetString("Token"));

            var response1 = client.Get<AutorViewModel>(request);

            return View(response1.Data);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nome,Sobrenome,Email,DataDeNascimento")] Autor autor)
        {
            if (id != autor.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(autor);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AutorExists(autor.Id))
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
            return View(autor);
        }
        // GET: Autors/Delete/5
        public ActionResult Delete(int? id)
        {
            var client = new RestClient();
            var request = new RestRequest("https://localhost:5001/api/autors/" + id, DataFormat.Json);
            request.AddHeader("Authorization", "Bearer " + this.HttpContext.Session.GetString("Token"));

            var response1 = client.Get<AutorViewModel>(request);

            return View(response1.Data);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            try
            {
                var autor = await _context.Autores.FindAsync(id);
                _context.Autores.Remove(autor);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));

            }
            catch (Exception)
            {
                throw;
            }

        }
        public ActionResult Livros(int id)
        {
            var client = new RestClient();

            var request = new RestRequest("https://localhost:5001/api/autors/" + id, DataFormat.Json);
            request.AddHeader("Authorization", "Bearer " + this.HttpContext.Session.GetString("Token"));

            var response = client.Get<Autor>(request);


            var autor = response.Data;
            var autorList = autor;
            var autorViewModel = mapper.Map<AutorViewModel>(autorList);
            var busca = LivroServices.GetLivrosById(autorViewModel.Id);
            var livros = mapper.Map <List<LivroViewModel>>(busca);
            autorViewModel.Livros = livros;
            return View(autorViewModel);
        }
        private bool AutorExists(int id)
        {
            return _context.Autores.Any(e => e.Id == id);
        }
    }
    public class TokenResult
    {
        public String Token { get; set; }
    }
}
