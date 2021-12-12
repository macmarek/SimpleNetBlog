using System.Text.Json;

namespace SimpleNetBlog.BusinessLogic.BlogConfig
{
    public class BlogConfigFromCfgFileService : IBlogConfigService
    {

        private readonly BlogConfig staticCfg;

        public BlogConfigFromCfgFileService()
        {
            string jsonString = File.ReadAllText("./BlogData/blogdata.json");
            staticCfg = JsonSerializer.Deserialize<BlogConfig>(jsonString);
        }
        
        
        public BlogConfig GetConfig()
        {
            return this.staticCfg;
        }

        BlogConfigArticle IBlogConfigService.GetByUrlKey(string key)
        {
            BlogConfigArticle ret = null;
            foreach(var g in this.staticCfg.Groups)
            {
                ret = g.Articles.SingleOrDefault(x => x.UrlKey == key);
                if(ret!=null)
                {
                    break;
                }
            }
            return ret;
        }
    }
}
