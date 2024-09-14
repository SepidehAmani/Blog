
using Blog.MVC.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Diagnostics;
using System.Text.Json;

namespace Blog.MVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly HttpClient httpClient;
        private readonly IHttpClientFactory _factory;

        public HomeController(ILogger<HomeController> logger, IHttpClientFactory factory)
        {
            _logger = logger;
            _factory = factory;
            this.httpClient = _factory.CreateClient("BlogService");
        }

        public IActionResult Index()
        {
            return View();
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

        public async Task<IActionResult> GetBlogPost(int id)
        {
            var res = await httpClient.GetAsync($"api/Blog/{id}");
            res.EnsureSuccessStatusCode();
            var jsonRes = await res.Content.ReadAsStringAsync();
            var model = JsonConvert.DeserializeObject<GetBlogPostWithCommentsDTO>(jsonRes);
            return View(model);
        }

        public async Task<IActionResult> GetAllBlogPosts()
        {
            var res = await httpClient.GetAsync("api/Blog");
            res.EnsureSuccessStatusCode();
            var jsonRes = await res.Content.ReadAsStringAsync();
            var model = JsonConvert.DeserializeObject<ICollection<GetBlogpostDTO>>(jsonRes);
            return View(model);
        }
    }
}
