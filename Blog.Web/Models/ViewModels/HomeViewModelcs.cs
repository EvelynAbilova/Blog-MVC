using Blog.Web.Models.Domain;

namespace Blog.Web.Models.ViewModels
{
    public class HomeViewModelcs
    {
        public IEnumerable<BlogPost> BlogPosts { get; set; }
        public IEnumerable<Tag> Tags { get; set; }
    }
}
