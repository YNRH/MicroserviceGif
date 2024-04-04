using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using MiFrontend.Models;

namespace MiFrontend.Services
{
    public class GifService
    {
        private readonly HttpClient _httpClient;

        public GifService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<Gif>> GetGifs()
        {
            return await _httpClient.GetFromJsonAsync<List<Gif>>("http://backend:8080/gif");
        }
    }
}
