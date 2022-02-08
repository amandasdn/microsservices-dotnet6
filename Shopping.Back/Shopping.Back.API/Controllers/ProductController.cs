using Microsoft.AspNetCore.Mvc;
using Shopping.API.Data.ValueObjects;
using Shopping.API.Interfaces.Repository;
using Shopping.Back.API.Model;
using Shopping.Back.API.Utility;

namespace Shopping.Back.API.Controllers
{
    [ApiController]
    [Route("api/v1.0/[controller]")]
    public class ProductController : Controller
    {
        private readonly ILogger<ProductController> _logger;
        private readonly IProductRepository _productRepository;

        public ProductController(IProductRepository productRepository, ILogger<ProductController> logger)
        {
            _logger = logger;
            _productRepository = productRepository ?? throw new ArgumentNullException(nameof(productRepository));
        }

        [HttpGet]
        [ProducesResponseType(typeof(Result<IEnumerable<ProductVO>>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(Result), StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Get()
        {
            try
            {
                var products = await _productRepository.ListAll();

                return this.SetOk(products);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);

                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        [HttpGet("{id}")]
        [ProducesResponseType(typeof(Result<ProductVO>), StatusCodes.Status200OK)]
        public async Task<IActionResult> Get(int id)
        {
            var product = await _productRepository.FindById(id);

            if (product != null) return Ok(product);

            return BadRequest();
        }

        // [HttpPost("teste")]
        // public IActionResult Post(ProductVO product)
        // {
        //     return CreatedAtAction(nameof(Get), new { id = 3 }, product);
        // }

        [HttpPost]
        [ProducesResponseType(typeof(Result<ProductVO>), StatusCodes.Status200OK)]
        public async Task<IActionResult> Create([FromBody] ProductVO product)
        {
            var productCreated = await _productRepository.Create(product);

            if (productCreated != null) return Ok(productCreated);

            return this.SetOk();
        }

        [HttpDelete]
        public async Task<IActionResult> Delete()
        {
            // var products = await _productRepository.Create(product);

            return Ok();
        }
    }
}
