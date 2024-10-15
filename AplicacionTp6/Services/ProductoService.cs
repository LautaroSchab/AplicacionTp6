using AplicacionTp6.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using AplicacionTp6.Utils;
using System.Net.Http.Json;

namespace AplicacionTp6.Services
{
    public class ProductoService:IProductoService
    {
        HttpClient client;

        private static JsonSerializerOptions options = new()
        {
            PropertyNameCaseInsensitive = true
        };

        public ProductoService()
        {
            client = new HttpClient();

            client.BaseAddress = new Uri(Constants.ApiDataServer);
            client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));
        }

        public async Task<IEnumerable<Producto>> GetProductsAsync()
        {
            var response = await client.GetAsync(Constants.ProductsEndpoint);

            if (response.IsSuccessStatusCode)
                return await response.Content.ReadFromJsonAsync<IEnumerable<Producto>>(options);

            return default;
        }

        public async Task<Producto> CreateProductAsync(Producto producto)
        {
            var response = await client.PostAsJsonAsync(Constants.ProductsEndpoint, producto);

            if (response.IsSuccessStatusCode)
                return await response.Content.ReadFromJsonAsync<Producto>(options);

            return default;
        }
    }
}
