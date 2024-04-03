
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace MiBackend.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class GifController : ControllerBase
    {
        private readonly HttpClient _httpClient;

        public GifController(IHttpClientFactory httpClientFactory)
        {
            _httpClient = httpClientFactory.CreateClient();
        }

        [HttpGet]
        public async Task<IActionResult> GetGifs()
        {
            string apiKey = "LIVDSRZULELA";
            string searchQuery = "excited";
            int limit = 8;

            var response = await _httpClient.GetAsync($"https://g.tenor.com/v1/search?q={searchQuery}&key={apiKey}&limit={limit}");

            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                var gifs = JsonConvert.DeserializeObject<TenorResponse>(content);
                return Ok(gifs.Results);
            }
            else
            {
                return StatusCode((int)response.StatusCode, "Failed to retrieve GIFs from Tenor API");
            }
        }
    }

    public class TenorResponse
    {
        public List<GifResult> Results { get; set; }
    }

    public class GifResult
    {
        public string Id { get; set; }
        public Media[] Media { get; set; }
    }

    public class Media
    {
        public Webm Webm { get; set; }
    }

    public class Webm
    {
        public string Preview { get; set; }
    }
}
