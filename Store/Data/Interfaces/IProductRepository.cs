using Store.Data.Models;
using System.Collections;
using System.Collections.Generic;

namespace Store.Data.Interfaces
{
    public interface IProductRepository
    {
        IEnumerable<Product> Products { get; }
        IEnumerable<Product> PreferedProducts { get; }
        Product GetProductById(int ProductId);


    }
}
