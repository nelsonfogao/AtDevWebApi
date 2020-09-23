using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using ApplicationService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using RestSharp;
using Web.ApiServices;
using Web.Models;
using Web.Models.Autor;
using WebApp.Models;

namespace WebApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly AutorServices services;
        private readonly LivroServices services2;

        public HomeController(ILogger<HomeController> logger, AutorServices services, LivroServices services2)
        {
            _logger = logger;
            this.services = services;
            this.services2 = services2;
        }

        public ActionResult Index()
        {
            var paginaInicial = new PaginaInicialViewModel();

            var autors = services.GetAll();
            paginaInicial.QuantidadeDeAutors = autors.Count;

            var livros = services2.GetAll();
            paginaInicial.QuantidadeDeLivros = livros.Count;

            return View(paginaInicial);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
