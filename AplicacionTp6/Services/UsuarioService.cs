using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using AplicacionTp6.Models;
using AplicacionTp6.Utils;
namespace AplicacionTp6.Services
{
    public class UsuarioService:IUsuarioService
    {
        HttpClient client;

        private static JsonSerializerOptions options = new()
        {
            PropertyNameCaseInsensitive = true
        };

        public UsuarioService()
        {
            client = new HttpClient();

            client.BaseAddress = new Uri(Constants.ApiDataServer);
            client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));
        }
        
        public async Task<IEnumerable<Usuario>> GetUsersAsync()
        {
            var response = await client.GetAsync(Constants.UsersEndpoint);

            if (response.IsSuccessStatusCode)
                return await response.Content.ReadFromJsonAsync<IEnumerable<Usuario>>(options);

            return default;
        }

        public async Task<Usuario> CreateUserAsync(Usuario usuario)
        {
            var response = await client.PostAsJsonAsync(Constants.UsersEndpoint, usuario);

            if (response.IsSuccessStatusCode)
                return await response.Content.ReadFromJsonAsync<Usuario>(options);

            return default;
        }
    }
}
