using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Store.Data.Interfaces;
using Store.Data.Models;

namespace Store.Controllers
{
    public class OrderController : Controller
    {
        private readonly IOrderRepository orderRepository;
        private readonly ShoppingCart shoppingCart;

        public OrderController(IOrderRepository orderRepository, ShoppingCart shoppingCart)
        {
            this.orderRepository = orderRepository;
            this.shoppingCart = shoppingCart;
        }
        [Authorize]

        public IActionResult Checkout()
        {
            return View();
        }
        [HttpPost]
        [Authorize]
        public IActionResult Checkout(Order order)
        {
            var items = shoppingCart.GetShoppingCartItems();
            shoppingCart.ShoppingCartItems = items;

            if (shoppingCart.ShoppingCartItems.Count == 0)
            {
                ModelState.AddModelError("", "Your card is empty, add some product first.");
            }

            if (ModelState.IsValid)
            {
                orderRepository.CreateOrder(order);
                shoppingCart.ClearCart();
                return RedirectToAction("CheckoutComplete");
            }

            return View(order);
        }
        
        public IActionResult CheckoutComplete()
        {
            ViewBag.CheckoutCompleteMessage = "Thanks for your order!";
            return View();
        }
    }
}
