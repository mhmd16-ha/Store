using Store.Data.Models;
using System.Collections.Generic;

namespace Store.ViewModels
{
    public class HomeViewModel
    {
        public IEnumerable<Product> PreferredProduct{ get; set; }
    }
}
