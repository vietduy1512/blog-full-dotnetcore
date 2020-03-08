using BlogNetCore.AppService.DTO;
using ReflectionIT.Mvc.Paging;
using System.Collections.Generic;

namespace BlogNetCore.MVC.Models
{
    public class PostDetailsViewModel
    {
        public PostDto Post { get; set; }
        public CommentDto Comment { get; set; }
    }

    public class PostIndexViewModel
    {
        public IPagingList<PostDto> PostList { get; set; }
    }

    public class PostCreateViewModel
    {
        public List<CategoryDto> Categories { get; set; }
        public PostDto Post { get; set; }
    }

    public class PostEditViewModel
    {
        public List<CategoryDto> Categories { get; set; }
        public PostDto Post { get; set; }
    }
}
