namespace SimpleNetBlog.BusinessLogic
{
    public interface IMarkdownService
    {
        string ConvertToHtml(string markDownText);
    }
}
