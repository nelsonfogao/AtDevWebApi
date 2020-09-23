using Domain;
using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Web.ApiServices;
using Web.Controllers;
using Web.Models.Autor;

namespace Web.ApiServices
{
    public class AutorApi : IAutorApi
    {
        private readonly HttpClient httpClient;

        public AutorApi()
        {
            httpClient = new HttpClient();
            httpClient.BaseAddress = new Uri("https://localhost:5001");
        }

        public async Task<AutorViewModel> GetAutor(int id)
        {
            var response = await httpClient.GetAsync($"api/carros/" + id);

            var content = await response.Content.ReadAsStringAsync();

            var viewModel = JsonConvert.DeserializeObject<AutorViewModel>(content);

            return viewModel;
        }

        public async Task<List<AutorViewModel>> GetAutors()
        {
            var response = await httpClient.GetAsync($"api/Autors");

            var content = await response.Content.ReadAsStringAsync();

            var viewModel = JsonConvert.DeserializeObject<List<AutorViewModel>>(content);

            return viewModel;
        }
    }
}
