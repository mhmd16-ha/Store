using Store.Data.Models;
using System.Collections.Generic;

namespace Store.ViewModels
{
    public class ShoppingCartViewModel
    {
        public ShoppingCart ShoppingCart { get; set; }
        public decimal ShoppingCartTotal { get; set; }
        public List<Category> category { get; set; }
    }
}
