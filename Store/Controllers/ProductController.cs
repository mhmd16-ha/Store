using Microsoft.AspNetCore.Mvc;
using Store.Data.Interfaces;
using Store.Data.Models;
using Store.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Store.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductRepository _product;
        private readonly ICategoryRepository _category;

        public ProductController(IProductRepository product,ICategoryRepository category)
        {
            _product = product;
            _category = category;
        }
        public ViewResult Index(string category)
        {
            string _category=category;
            IEnumerable<Product> products;
            string currentCategory = string.Empty;
            if (string.IsNullOrEmpty(category))
            {
                products = _product.Products.OrderBy(x => x.ProductId);
                currentCategory = "All Products";
            }
            else
            {
                if (string.Equals("ملابس", _category, StringComparison.OrdinalIgnoreCase))
                {
                    products=_product.Products.Where(p => p.Category.CategoryName.Equals("ملابس"));
                }
                else if(string.Equals("ترفيه", _category, StringComparison.OrdinalIgnoreCase))
                    {
                    products = _product.Products.Where(p => p.Category.CategoryName.Equals("ترفيه"));

                    }
                else
                {
                    products = _product.Products.Where(p => p.Category.CategoryName.Equals("الكترونيات"));

                }

                currentCategory = _category;
            }
            var model = new ProductModelView
            {
                Products = products,
                CurrentCategory = currentCategory,
            };

            return View(model);
        }
    }
}
