using BlogNetCore.AppService.DTO;
using BlogNetCore.AppService.Seedwork.ServiceContracts;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace BlogNetCore.MVC.Controllers
{
    public class CommentController : Controller
    {
        private readonly ICommentService commentService;

        public CommentController(ICommentService _commentService)
        {
            commentService = _commentService;
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddComment([Bind("Content,Id,UserId,PostId")] CommentDto comment)
        {
            if (ModelState.IsValid)
            {
                await commentService.AddAsync(comment);
                return ViewComponent("CommentSection", new { postId = comment.PostId });
            }
            return BadRequest();
        }
    }
}