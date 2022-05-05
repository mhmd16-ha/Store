using Store.Data.Interfaces;
using Store.Data.Models;
using System;

namespace Store.Data.Repositories
{
    public class OrderRepository : IOrderRepository
    {
        private readonly AppDbContext appDbContext;
        private readonly ShoppingCart shoppingCart;

        public OrderRepository(AppDbContext appDbContext, ShoppingCart shoppingCart)
        {
            this.appDbContext = appDbContext;
            this.shoppingCart = shoppingCart;
        }
        public void CreateOrder(Order order)
        {
            order.OrderPlaced = DateTime.UtcNow;
            appDbContext.Orders.Add(order);
            var shoppingCartItems = shoppingCart.ShoppingCartItems;
            foreach (var item in shoppingCartItems)
            {
                var orderDetail = new OrderDetails()
                {
                    Amount=item.Amount,
                    ProductId=item.Product.ProductId,
                    OrderId = order.OrderId,
                    Price=item.Product.Price,
                };
            }
            appDbContext.SaveChanges();

        }
    }
}
