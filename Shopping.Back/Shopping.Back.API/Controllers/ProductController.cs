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

        /// <summary>
        /// Get all the products.
        /// </summary>
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

                return this.SetInternalServerError(ex.Message);
            }
        }

        /// <summary>
        /// Get the product by ID.
        /// </summary>
        /// <param name="id">Product ID</param>
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(Result<ProductVO>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(Result), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(Result), StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Get(int id)
        {
            try
            {
                var product = await _productRepository.FindById(id);

                if (product != null) return this.SetOk(product);

                return this.SetNotFound("The product wasn't found.");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);

                return this.SetInternalServerError(ex.Message);
            }
        }

        /// <summary>
        /// Create a product.
        /// </summary>
        /// <param name="product">Product data</param>
        [HttpPost]
        [ProducesResponseType(typeof(Result<ProductVO>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(Result), StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Create([FromBody] ProductVO product)
        {
            try
            {
                var productCreated = await _productRepository.Create(product);

                if (productCreated != null) return this.SetOk(productCreated);

                return this.SetInternalServerError();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);

                return this.SetInternalServerError(ex.Message);
            }
        }

        /// <summary>
        /// Update a product.
        /// </summary>
        /// <param name="product">Product data</param>
        [HttpPut]
        [ProducesResponseType(typeof(Result<ProductVO>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(Result), StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Update([FromBody] ProductVO product)
        {
            try
            {
                var productUpdated = await _productRepository.Update(product);

                if (productUpdated != null) return this.SetOk(productUpdated);

                return this.SetNotFound("The product wasn't found.");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);

                return this.SetInternalServerError(ex.Message);
            }
        }

        /// <summary>
        /// Delete a product.
        /// </summary>
        /// <param name="id">Product ID</param>
        [HttpDelete]
        [ProducesResponseType(typeof(Result), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(Result), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(Result), StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var isDeleted = await _productRepository.Delete(id);

                if (isDeleted) return this.SetOk();

                return this.SetInternalServerError();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);

                return this.SetInternalServerError(ex.Message);
            }
        }
    }
}
