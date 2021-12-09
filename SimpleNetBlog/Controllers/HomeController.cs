using Microsoft.AspNetCore.Mvc;
using SimpleNetBlog.BusinessLogic.BlogConfig;
using SimpleNetBlog.Models;
using System.Diagnostics;

namespace SimpleNetBlog.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IBlogConfigService blogConfigService;

        public HomeController(ILogger<HomeController> logger, IBlogConfigService blogConfigService)
        {
            _logger = logger;
            this.blogConfigService = blogConfigService;
        }

        public IActionResult Index()
        {
            var blogConfig = this.blogConfigService.GetConfig();
            return View(blogConfig);
        }

        //public IActionResult DynamicBlogPost(string fileName)
        //{
        //    var mdPath = Path.Combine("./BlogData/", fileName);
        //    //var result = Markdown.ToHtml("This is a text with some *emphasis*");
        //    string readText = System.IO.File.ReadAllText(mdPath);
        //    var result = Markdown.ToHtml(readText);

        //    ViewBag.MDHtml = result;
        //    return View();
        //}

        //public IActionResult Privacy()
        //{
        //    return View();
        //}

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}