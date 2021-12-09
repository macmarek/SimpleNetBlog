namespace SimpleNetBlog.BusinessLogic.BlogConfig
{
    public class BlogConfigService : IBlogConfigService
    {

        private readonly BlogConfig staticCfg;

        public BlogConfigService()
        {
            this.staticCfg = new BlogConfig
            {
                BlogName = "allstack.org",
                Groups = new List<BlogConfigGroup> {
                    new BlogConfigGroup {
                        Name = "2021",
                        Articles = new List<BlogConfigArticle> {
                            new BlogConfigArticle
                            {
                                FilePath = "stack-javascript-data-structure.md",
                                Title = "Stack JavaScript data structure",
                                UrlKey = "stack-javascript-data-structure",
                                PublishDate = new DateTime(2021, 12, 9)
                            }

                        }
                    },
                    new BlogConfigGroup {
                        Name = "2022",
                        Articles = new List<BlogConfigArticle> {
                            new BlogConfigArticle
                            {
                                FilePath = "stack-javascript-data-structure-2.md",
                                Title = "Stack JavaScript data structure",
                                UrlKey = "stack-javascript-data-structure-2",
                                PublishDate = new DateTime(2022, 12, 9)
                            }

                        }
                    }

                }
            };
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
