using Markdig;
using Markdig.Extensions.AutoLinks;
using Markdig.Prism;
using Markdig.Renderers.Html;
using Markdig.Syntax;
using Markdig.Syntax.Inlines;
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
            var pipeline = new MarkdownPipelineBuilder()
    .UseAutoLinks(new AutoLinkOptions { OpenInNewWindow = true })
    .UseAdvancedExtensions()
    .UsePrism()
    .Build();
            //var result = Markdown.ToHtml(readText);
            //var result = Markdown.ToHtml(readText, pipeline);

            MarkdownDocument document = Markdown.Parse(readText, pipeline);

            foreach (LinkInline link in document.Descendants<LinkInline>())
            {
                link.GetAttributes().AddPropertyIfNotExist("target", "_blank");
            }

            foreach (AutolinkInline link in document.Descendants<AutolinkInline>())
            {
                link.GetAttributes().AddPropertyIfNotExist("target", "_blank");
            }

            var result = document.ToHtml(pipeline);

            ViewBag.MDHtml = result;
            return View();
        }
    }
}