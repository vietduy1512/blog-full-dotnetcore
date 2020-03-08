using BlogNetCore.AppService.Seedwork.DTO.Core;

namespace BlogNetCore.AppService.DTO
{
    public class CommentDto : BlogCoreDto<int>
    {
        public string Content { get; set; }
        public int? UserId { get; set; }
        public int? PostId { get; set; }
        public string PostCategory { get; set; }
        public string PostTitle { get; set; }
    }
}
