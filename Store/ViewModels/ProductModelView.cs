using Store.Data.Models;
using System.Collections.Generic;

namespace Store.ViewModels
{
    public class ProductModelView
    {
        public IEnumerable<Product> Products { get; set; }
        public string CurrentCategory { get; set; }
    }
}
