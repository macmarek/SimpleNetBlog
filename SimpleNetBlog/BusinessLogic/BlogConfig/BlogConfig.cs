namespace SimpleNetBlog.BusinessLogic.BlogConfig
{
    public class BlogConfig
    {
        public string BlogName { get; set; }

        public string BlogRelativeRootFolder { get; } = "./BlogData";

        public List<BlogConfigGroup> Groups { get; set; }
    }
}
