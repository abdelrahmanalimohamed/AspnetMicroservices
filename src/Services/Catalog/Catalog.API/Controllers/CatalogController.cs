using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using Catalog.API.Entities;
using Catalog.API.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Catalog.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CatalogController : ControllerBase
    {
        private IProductsRepository _productsRepository;
        private readonly ILogger<CatalogController> _logger;
        public CatalogController(
            IProductsRepository productsRepository , 
            ILogger<CatalogController> logger)
        {
            this._productsRepository = productsRepository;
            this._logger = logger;
        }

        [HttpGet("",Name ="GetProducts")]
        [Route("[action]/{category}", Name = "GetProducts")]
        [ProducesResponseType(typeof(IEnumerable<Products>), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<IEnumerable<Products>>> GetProductsList()
        {
            var result = await _productsRepository.GetProducts();
            return Ok(result);
        }

        [HttpGet]
        [Route("[action]/{category}", Name = "GetProductByCategory")]
        [ProducesResponseType(typeof(IEnumerable<Products>), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<IEnumerable<Products>>> GetProductsByCategoryName (string CategoryName)
        {
            var result = await _productsRepository.GetProductByCategory(CategoryName);
            return Ok(result);
        }

        [HttpGet("{id:length(24)}", Name = "GetProductsByID")]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        [ProducesResponseType(typeof(Products), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<Products>> GetProductsByID(string id)
        {
            var results = await _productsRepository.GetProduct(id);
            if (results == null)
            {
                _logger.LogError($"Product with id: {id}, not found.");
                return NotFound();
            }
            return Ok(results);
        }

        [HttpPost]
        [ProducesResponseType(typeof(Products), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<Products>> CreateProduct([FromBody] Products product)
        {
            await _productsRepository.CreateProduct(product);

            return CreatedAtRoute("GetProduct", new { id = product.Id }, product);
        }

        [HttpDelete("{id:length(24)}", Name = "DeleteProduct")]
        [ProducesResponseType(typeof(Products), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> DeleteProduct(string id)
        {
            return Ok(await _productsRepository.DeleteProduct(id));
        }
    }
}