using ProductsApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProductsApi.Repository
{
    public interface IProductRepository
    {
        Task<Product> Get(int id);

        Task<IEnumerable<Product>> GetAll();

        Task Add(Product product);

        Task Delete(int id);

        Task Update(Product product);
    }
}
