using AutoMapper.QueryableExtensions;
using BlogNetCore.AppService.Domain;
using BlogNetCore.AppService.DTO;
using BlogNetCore.AppService.Repository.Core;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace BlogNetCore.MVC.ViewComponents
{
    public class CommentSectionViewComponent : ViewComponent
    {
        private readonly IRepository<Comment> commentRepository;

        public CommentSectionViewComponent(IRepository<Comment> _commentRepository)
        {
            commentRepository = _commentRepository;
        }


        public async Task<IViewComponentResult> InvokeAsync(int postId)
        {
            var comments = await commentRepository.Query()
                                                .ProjectTo<CommentDto>()
                                                .Where(x => x.PostId == postId)
                                                .OrderBy(x => x.CreatedDate)
                                                .ToListAsync();
            return View("CommentList", comments);
        }
    }
}
