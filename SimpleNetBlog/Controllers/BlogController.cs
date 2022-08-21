using Microsoft.AspNetCore.Mvc;
using SimpleNetBlog.BusinessLogic;
using SimpleNetBlog.BusinessLogic.BlogConfig;

namespace SimpleNetBlog.Controllers
{
    public class BlogController : Controller
    {
        private readonly ILogger<BlogController> _logger;
        private readonly IMarkdownService markdownService;
        private readonly IBlogConfigService blogConfigService;

        public BlogController(ILogger<BlogController> logger, IMarkdownService markdownService, IBlogConfigService blogConfigService)
        {
            _logger = logger;
            this.markdownService = markdownService;
            this.blogConfigService = blogConfigService;
        }

        public IActionResult Index(string urlKey)
        {
            var article = this.blogConfigService.GetByUrlKey(urlKey);
            var blogConfig = this.blogConfigService.GetConfig();

            var mdPath = Path.Combine("./BlogData/", article.FilePath);
            //var result = Markdown.ToHtml("This is a text with some *emphasis*");
            string mdText = System.IO.File.ReadAllText(mdPath);


            ViewBag.MDHtml = this.markdownService.ConvertToHtml(mdText);
            ViewBag.BlogName = blogConfig.BlogName;
            ViewBag.ArticleTitle = article.Title;

            return View();
        }
    }
}