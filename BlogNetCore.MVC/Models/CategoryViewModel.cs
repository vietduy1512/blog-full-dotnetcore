using BlogNetCore.AppService.DTO;
using ReflectionIT.Mvc.Paging;

namespace BlogNetCore.MVC.Models
{
    public class PostListByCategoryViewModel
    {
        public IPagingList<PostDto> PostList { get; set; }
        public CategoryDto Category { get; set; }
    }
}
