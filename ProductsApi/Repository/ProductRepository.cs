using Microsoft.EntityFrameworkCore;
using ProductsApi.Data;
using ProductsApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProductsApi.Repository
{
    public class ProductRepository : IProductRepository
    {
        private readonly IDataContext context;

        public ProductRepository(IDataContext _context)
        {
             context = _context;
        }

        public async Task Add(Product product)
        {
            context.Products.Add(product);
            await context.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            var itemDelete = await context.Products.FindAsync(id);
            if (itemDelete == null)
                throw new NullReferenceException();

            context.Products.Remove(itemDelete);
            await context.SaveChangesAsync();
        }                                       

        public async Task<Product> Get(int id)
        {
            return await context.Products.FindAsync(id);
        }

        public async Task<IEnumerable<Product>> GetAll()
        {
            return await context.Products.ToListAsync();
        }

        public async Task Update(Product product)
        {
            var itemToUpdate = await context.Products.FindAsync(product.Id);
            if (itemToUpdate == null)
                throw new NullReferenceException();

            itemToUpdate.Name = product.Name;
            itemToUpdate.Price = product.Price;
            await context.SaveChangesAsync();
        }
    }
}
