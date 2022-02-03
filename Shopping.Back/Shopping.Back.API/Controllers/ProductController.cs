using Microsoft.AspNetCore.Mvc;
using Shopping.API.Interfaces.Repository;

namespace Shopping.Back.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductController : Controller
    {
        private readonly IProductRepository _productRepository;

        public ProductController(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var products = await _productRepository.ListAll();

            return Ok(products);
        }
    }
}
