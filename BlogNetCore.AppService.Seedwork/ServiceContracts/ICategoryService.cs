using BlogNetCore.AppService.DTO;
using BlogNetCore.AppService.Seedwork.ServiceContracts.Core;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BlogNetCore.AppService.Seedwork.ServiceContracts
{
    public interface ICategoryService : IService
    {
        Task<CategoryDto> GetCategoryByIdAsync(int id);
        Task<List<CategoryDto>> GetAllCategoryAsync();
        bool IsExist(int id);
        Task<int> AddAsync(CategoryDto dto);
        Task<int> UpdateAsync(CategoryDto dto);
        Task<int> RemoveAsync(int id);
    }
}
