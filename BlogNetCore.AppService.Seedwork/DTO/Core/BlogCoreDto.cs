using System;

namespace BlogNetCore.AppService.Seedwork.DTO.Core
{
    public class BlogCoreDto<TId> : BaseDto<TId>
    {
        public string CreatedBy { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
    }
}
