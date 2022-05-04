using Store.Data.Interfaces;
using Store.Data.Models;
using System.Collections.Generic;

namespace Store.Data.Repositories
{
    public class CategoryRepository: ICategoryRepository
    {
        private readonly AppDbContext _context;

        public CategoryRepository(AppDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Category> Categories => _context.categories;
    }
}
