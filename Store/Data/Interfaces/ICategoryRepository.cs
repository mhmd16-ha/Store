using Store.Data.Models;
using System.Collections.Generic;

namespace Store.Data.Interfaces
{
    public interface ICategoryRepository
    {
        IEnumerable<Category> Categories { get; }

    }
}
