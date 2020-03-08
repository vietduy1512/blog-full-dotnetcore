using BlogNetCore.AppService.DTO;
using BlogNetCore.AppService.Seedwork.ServiceContracts.Core;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BlogNetCore.AppService.Seedwork.ServiceContracts
{
    public interface ICommentService : IService
    {
        Task<CommentDto> GetPostByIdAsync(int id);
        Task<List<CommentDto>> GetAllCommentAsync();
        Task<int> AddAsync(CommentDto dto);
        Task<int> RemoveAsync(int id);
    }
}
