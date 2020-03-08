using BlogNetCore.AppService.Domain.Core;
using BlogNetCore.AppService.Identity;
using System.ComponentModel.DataAnnotations;

namespace BlogNetCore.AppService.Domain
{
    public class Comment : BlogCoreEntity<int>
    {
        [Required, StringLength(1000)]
        public string Content { get; set; }

        public int? UserId { get; set; }
        public virtual User User { get; set; }

        public int? PostId { get; set; }
        public virtual Post Post { get; set; }
    }
}
