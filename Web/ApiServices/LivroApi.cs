using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Web.ApiServices;
using Web.Models.Livro;

namespace Web.ApiServices
{
    public class LivroApi : ILivroApi
    {
        private readonly HttpClient httpClient = new HttpClient();
        private readonly IAutorApi autorApi;

        public LivroApi(IAutorApi autorApi)
        {
            this.autorApi = autorApi;
        }


        public async Task<List<LivroViewModel>> GetLivros()
        {

            var response = await httpClient.GetAsync($"https://localhost:5001/api/livros");

            var content = await response.Content.ReadAsStringAsync();

            var viewModel = JsonConvert.DeserializeObject<List<LivroViewModel>>(content);

            return viewModel;
        }

        public async Task<LivroViewModel> GetLivro(int id)
        {

            var response = await httpClient.GetAsync($"https://localhost:5001/api/livros/" + id);

            var content = await response.Content.ReadAsStringAsync();

            var viewModel = JsonConvert.DeserializeObject<LivroViewModel>(content);

            viewModel.Autor = await autorApi.GetAutor(viewModel.AutorId);

            return viewModel;
        }

        public Task PostLivro(CriaLivroViewModel form)
        {
            var json = JsonConvert.SerializeObject(form);

            var content = new StringContent(json, Encoding.UTF8, "application/json");

            httpClient.PostAsync($"https://localhost:5001/api/livros", content);

            return Task.CompletedTask;
        }
    }
}
