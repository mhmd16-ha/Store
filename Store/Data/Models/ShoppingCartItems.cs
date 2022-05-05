using System.ComponentModel.DataAnnotations;

namespace Store.Data.Models
{
    public class ShoppingCartItems
    {
        [Key]
        public int ShoppingCartItemId { get; set; }
        public Product Product { get; set; }
        public int Amount { get; set; }
        public string ShoppingCartId { get; set; }
    }
}
