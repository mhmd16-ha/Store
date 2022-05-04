using Microsoft.EntityFrameworkCore;
using Store.Data.Interfaces;
using Store.Data.Models;
using System.Collections.Generic;
using System.Linq;

namespace Store.Data.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly AppDbContext _context;

        public ProductRepository(AppDbContext context)
        {
            _context = context;
        }
        public IEnumerable<Product> Products => _context.products.Include(c => c.Category);

        public IEnumerable<Product> PreferedProducts => _context.products.Where(x=>x.IsPreferredDrink).Include(x=>x.Category);

        public Product GetProductById(int ProductId)
        {
            return _context.products.FirstOrDefault(x=>x.ProductId == ProductId);
        }
    }
}
