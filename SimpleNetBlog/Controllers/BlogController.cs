using Markdig;
using Microsoft.AspNetCore.Mvc;

namespace SimpleNetBlog.Controllers
{
    public class BlogController : Controller
    {
        private readonly ILogger<BlogController> _logger;

        public BlogController(ILogger<BlogController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index(string fileTitle)
        {
            var mdPath = Path.Combine("./BlogData/", fileTitle +".md");
            //var result = Markdown.ToHtml("This is a text with some *emphasis*");
            string readText = System.IO.File.ReadAllText(mdPath);
            var result = Markdown.ToHtml(readText);

            ViewBag.MDHtml = result;
            return View();
        }
    }
}