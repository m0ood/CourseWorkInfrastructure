using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using WebCourseWork.Web.Models;
using Newtonsoft.Json;
using System.Net.Http.Headers;

namespace WebCourseWork.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private List<Player>? Players = new List<Player>();
        private HttpClient _client;
        public HomeController(ILogger<HomeController> logger)
        {
            string? API = Environment.GetEnvironmentVariable("WebCourseWork");
            _logger = logger;
            _client = new HttpClient();
            _client.BaseAddress = new Uri(API);
            _client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }

        public async Task<IActionResult> IndexAsync()
        {
            HttpResponseMessage response;
            response = await _client.GetAsync("PlayerController");
            if (response.IsSuccessStatusCode)
            {
                var result = await response.Content.ReadAsStringAsync();
                Players = JsonConvert.DeserializeObject<List<Player>>(result);
            }
            return View(Players);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}