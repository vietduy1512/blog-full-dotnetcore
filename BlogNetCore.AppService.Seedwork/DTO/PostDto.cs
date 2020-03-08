using BlogNetCore.AppService.Seedwork.DTO.Core;
using System.Collections.Generic;

namespace BlogNetCore.AppService.DTO
{
    public class PostDto : BlogCoreDto<int>
    {
        public string Title { get; set; }
        public string Slug { get; set; }
        public string Description { get; set; }
        public string ImagePath { get; set; }
        public string Content { get; set; }

        public int CategoryId { get; set; }
        public string CategoryName { get; set; }

        public int AuthorId { get; set; }

        public List<CommentDto> Comments { get; set; }
    }
}
