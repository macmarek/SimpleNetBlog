namespace SimpleNetBlog.BusinessLogic.BlogConfig
{
    public interface IBlogConfigService
    {
        BlogConfig GetConfig();

        BlogConfigArticle GetByUrlKey(string key);
    }
}
