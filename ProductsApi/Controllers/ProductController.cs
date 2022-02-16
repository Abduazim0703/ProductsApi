using Microsoft.AspNetCore.Mvc;
using ProductsApi.Dtos;
using ProductsApi.Models;
using ProductsApi.Repository;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ProductsApi.Controllers
{
    [ApiController]
    [Route("[controller]")]

    public class ProductController: ControllerBase
    {
        private readonly IProductRepository productRepository;

        public ProductController(IProductRepository productRepository)
        {
            this.productRepository = productRepository;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Product>> GetProduct(int id)
        {
            var product = await productRepository.Get(id);
            if (product == null)
                return NotFound();

            return Ok(product);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<IEnumerable<Product>>> GetProducts()
        {
            var products = await productRepository.GetAll();
            if (products == null)
                return NotFound();

            return Ok(products);
        }

        [HttpPost]
        public async Task<IActionResult> CreateProduct(CreateProductDto createProductDto)
        {
            Product product = new()
            {
                Name = createProductDto.Name,
                Price = createProductDto.Price
            };

            await productRepository.Add(product);
            return Ok();
        }


        [HttpDelete]
        public async Task<ActionResult> DeleteProduct(int id)
        {
            await productRepository.Delete(id);
            return Ok();
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateProduct(int id, UpdateProductDto updateProductDto)
        {
            Product product = new()
            {
                Name = updateProductDto.Name,
                Price = updateProductDto.Price
            };

            await productRepository.Update(product);
            return Ok();

        }

    }
}
