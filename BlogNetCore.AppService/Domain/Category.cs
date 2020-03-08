using BlogNetCore.AppService.Domain.Core;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BlogNetCore.AppService.Domain
{
    public class Category : BlogCoreEntity<int>
    {
        [Required, StringLength(100)]
        public string Name { get; set; }

        [StringLength(100)]
        public string Description { get; set; }

        public virtual IEnumerable<Post> Posts { get; set; }
    }
}
