
using Microsoft.AspNetCore.Mvc;
using Store.Data.Interfaces;
using System;
using System.Linq;

namespace Store.ViewModels
{
    public class CategoryMenu : ViewComponent
    {
        private readonly ICategoryRepository _categoryRepository;

        public CategoryMenu(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository ??
                throw new ArgumentNullException(nameof(categoryRepository));
        }

        public IViewComponentResult Invoke()
        {
            var categories = _categoryRepository.Categories.OrderBy(p => p.CategoryName);

            return View(categories);
        }
    }
}
