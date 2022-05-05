using Microsoft.AspNetCore.Mvc;
using Store.Data.Models;
using System;

namespace Store.ViewModels
{
    public class ShoppingCartSummary : ViewComponent
    {
        
        
            private readonly ShoppingCart _shoppingCart;

            public ShoppingCartSummary(ShoppingCart shoppingCart)
            {
                _shoppingCart = shoppingCart ??
                    throw new ArgumentNullException(nameof(shoppingCart));
            }

            public IViewComponentResult Invoke()
            {
            var items = _shoppingCart.GetShoppingCartItems();
            _shoppingCart.ShoppingCartItems = items;

            var shoppingCartViewModel = new ShoppingCartViewModel
                {
                    ShoppingCart = _shoppingCart,
                    ShoppingCartTotal = _shoppingCart.GetShoppingCartTotal()
                };

                return View(shoppingCartViewModel);
            }
        }
    }

