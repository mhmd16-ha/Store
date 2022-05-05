using Microsoft.AspNetCore.Mvc;
using Store.Data.Interfaces;
using Store.Data.Models;
using Store.ViewModels;
using System.Linq;

namespace Store.Controllers
{
    public class ShoppingCartController : Controller
    {
        private readonly IProductRepository _ProductRepository;
        private readonly ICategoryRepository _categoryRepository;
        private readonly ShoppingCart _shoppingCart;

        public ShoppingCartController(IProductRepository ProductRepository, ICategoryRepository CategoryRepository, ShoppingCart shoppingCart)
        {
            _ProductRepository = ProductRepository;
            _categoryRepository = CategoryRepository;
            _shoppingCart = shoppingCart;
        }
            public IActionResult Index()
        {
            var items = _shoppingCart.GetShoppingCartItems();
            _shoppingCart.ShoppingCartItems = items;
            var sCVM = new ShoppingCartViewModel
            {
                ShoppingCart = _shoppingCart,
                ShoppingCartTotal = _shoppingCart.GetShoppingCartTotal(),
                category = _categoryRepository.Categories.ToList(),

            };
            return View(sCVM);
        }
        public  RedirectToActionResult AddToShoppingCart(int productId)
        {
            var selectedItem = _ProductRepository.Products.FirstOrDefault(p => p.ProductId == productId);
            if (selectedItem != null)
            {
                _shoppingCart.AddToCart(selectedItem, 1);
            }
            return RedirectToAction("Index");
        }
        public RedirectToActionResult RemoveFromShoppingCart(int productId)
        {
            var selectedItem = _ProductRepository.Products.FirstOrDefault(p => p.ProductId == productId);
            if (selectedItem != null)
            {
                _shoppingCart.RemoveFromCart(selectedItem);
            }
            return RedirectToAction("Index");
        }
    }
}
