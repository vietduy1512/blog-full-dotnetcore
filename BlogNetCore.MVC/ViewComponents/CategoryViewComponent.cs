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
    public class CategoryListViewComponent : ViewComponent
    {
        private readonly IRepository<Category> categoryRepository;

        public CategoryListViewComponent(IRepository<Category> _categoryRepository)
        {
            categoryRepository = _categoryRepository;
        }


        public async Task<IViewComponentResult> InvokeAsync()
        {
            var categories = await categoryRepository.Query()
                                                .ProjectTo<CategoryDto>()
                                                .OrderByDescending(x => x.Name)
                                                .ToListAsync();
            return View("CategoryList", categories);
        }
    }
}
