using BlogNetCore.AppService.Seedwork.DTO.Core;

namespace BlogNetCore.AppService.DTO
{
    public class CategoryDto : BlogCoreDto<int>
    {
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
