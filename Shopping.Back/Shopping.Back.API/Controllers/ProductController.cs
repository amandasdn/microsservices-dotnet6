using Microsoft.AspNetCore.Mvc;
using Shopping.API.Data.ValueObjects;
using Shopping.API.Interfaces.Repository;
using Shopping.API.Model;

namespace Shopping.Back.API.Controllers
{
    [ApiController]
    [Route("api/v1.0/[controller]")]
    public class ProductController : Controller
    {
        private readonly IProductRepository _productRepository;

        public ProductController(IProductRepository productRepository)
        {
            _productRepository = productRepository ?? throw new ArgumentNullException(nameof(productRepository));
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var products = await _productRepository.ListAll();

            return Ok(products);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var product = await _productRepository.FindById(id);

            if (product != null) return Ok(product);

            return BadRequest();
        }

        [HttpPost("teste")]
        public IActionResult Post(ProductVO product)
        {
            return CreatedAtAction(nameof(Get), new { id = 3 }, product);
        }

        [HttpPost]
        public async Task<IActionResult> Create(ProductVO product)
        {
            // var products = await _productRepository.Create(product);

            return Ok(product);
        }

        [HttpDelete]
        public async Task<IActionResult> Delete()
        {
            // var products = await _productRepository.Create(product);

            return Ok();
        }
    }
}
