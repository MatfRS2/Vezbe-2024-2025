using Catalog.API.Data;
using Catalog.API.Entities;
using Catalog.API.Repositories;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Driver;

namespace Catalog.API.Contollers;

[ApiController]
[Route("api/v1/[controller]")]
public class CatalogController : ControllerBase
{
    private readonly IProductRepository _repository;

    public CatalogController(IProductRepository repository)
    {
        _repository = repository ?? throw new ArgumentNullException(nameof(repository));
    }

    [HttpGet]
    [ProducesResponseType(typeof(IEnumerable<Product>), StatusCodes.Status200OK)]
    public async Task<ActionResult<IEnumerable<Product>>> GetProducts()
    {
        var products = await _repository.GetProducts();

        return Ok(products);
    }

    [HttpGet("{id}", Name = "GetProduct")]
    [ProducesResponseType(typeof(Product), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(Product), StatusCodes.Status404NotFound)]
    public async Task<ActionResult<Product>> GetProduct(string id)
    {
        var product = await _repository.GetProductById(id);
        if (product == null)
        {
            return NotFound(null);
        }

        return Ok(product);
    }
    [Route("[action]/{category}")]
    [HttpGet]
    [ProducesResponseType(typeof(IEnumerable<Product>), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<IEnumerable<Product>>> GetProductsByCategory(string category)
    {
        var products = await _repository.GetProductByCategory(category);
        if(products == null)
            return NotFound(null);
        return Ok(products);
    }

    [HttpPost]
    [ProducesResponseType(typeof(Product), StatusCodes.Status201Created)]
    public async Task<ActionResult<Product>> CreateProduct([FromBody] Product product)
    {
        await _repository.CreateProduct(product);
        return CreatedAtAction("GetProduct", new { id = product.Id }, product);
    }

    [HttpPut]
    [ProducesResponseType( StatusCodes.Status200OK)]
    [ProducesResponseType( StatusCodes.Status404NotFound)]
    public async Task<IActionResult> UpdateProduct([FromBody] Product product)
    {
        var result = await _repository.UpdateProduct(product);
        if(!result)
            return NotFound(null);
        return Ok();
    }

    [HttpDelete]
    [ProducesResponseType( StatusCodes.Status200OK)]
    [ProducesResponseType( StatusCodes.Status404NotFound)]

    public async Task<ActionResult> DeleteProduct(string id)
    {
        var result = await _repository.DeleteProduct(id);
        if(!result)
            return NotFound(null);
        return Ok();
    }
    
}