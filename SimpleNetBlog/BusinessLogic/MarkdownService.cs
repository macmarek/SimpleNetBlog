using Markdig.Extensions.AutoLinks;
using Markdig.Syntax.Inlines;
using Markdig.Syntax;
using Markdig;
using Markdig.Renderers.Html;
using Markdig.Prism;

namespace SimpleNetBlog.BusinessLogic
{
    public class MarkdownService : IMarkdownService
    {
        public string ConvertToHtml(string markDownText)
        {
            var pipeline = new MarkdownPipelineBuilder()
                .UseAutoLinks(new AutoLinkOptions { OpenInNewWindow = true })
                .UseAdvancedExtensions()
                .UsePrism()
                .Build();
            //var result = Markdown.ToHtml(readText);
            //var result = Markdown.ToHtml(readText, pipeline);

            MarkdownDocument document = Markdown.Parse(markDownText, pipeline);

            foreach (LinkInline link in document.Descendants<LinkInline>())
            {
                link.GetAttributes().AddPropertyIfNotExist("target", "_blank");
            }

            foreach (AutolinkInline link in document.Descendants<AutolinkInline>())
            {
                link.GetAttributes().AddPropertyIfNotExist("target", "_blank");
            }

            var result = document.ToHtml(pipeline);
            return result;
        }
    }
}
