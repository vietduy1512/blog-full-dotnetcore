using System;

namespace BlogNetCore.AppService.Domain.Core
{
    public class BlogCoreEntity<TId> : BaseEntity<TId>
    {
        public BlogCoreEntity()
        {
            CreatedDate = DateTime.Now;
        }

        public string CreatedBy { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
    }
}
