using InspectorAR.Product.AddProduct;
using InspectorAR.Product.Common.Handlers;
using InspectorAR.Product.Common.Models;
using InspectorAR.Product.UpdateProduct;
using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.AspNetCore.Mvc;

namespace InspectorAR.Controllers;

/// <summary>
/// Product controller.
/// </summary>
[ApiController]
[Route("[controller]")]
public class ProductController : ControllerBase
{
    /// <summary>
    /// Get a product by id.
    /// </summary>
    /// <param name="id"></param>
    /// <param name="handler"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [HttpGet("{id:guid}")]
    public async Task<ActionResult<ProductViewModel>> GetProductById(Guid id, [FromServices] ProductQueryHandler handler, CancellationToken cancellationToken)
    {
        return Ok(await handler.GetProductAsync(id, cancellationToken));
    }
    
    /// <summary>
    /// Add a new product.
    /// </summary>
    /// <param name="command"></param>
    /// <param name="handler"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    [ProducesResponseType(StatusCodes.Status201Created)]
    [HttpPost]
    public async Task<ActionResult<ProductViewModel>> AddProduct([FromBody] AddProductCommand command, [FromServices] ProductCommandHandler handler, CancellationToken cancellationToken)
    {
        return Created(HttpContext.Request.GetDisplayUrl(),await handler.AddProductAsync(command, cancellationToken));
    }
    
    /// <summary>
    /// Update a product by id.
    /// </summary>
    /// <param name="id"></param>
    /// <param name="command"></param>
    /// <param name="handler"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [HttpPatch("{id:guid}")]
    public async Task<ActionResult<ProductViewModel>> UpdateProduct(Guid id, [FromBody] UpdateProductCommand command, [FromServices] ProductCommandHandler handler, CancellationToken cancellationToken)
    {
        command.SetId(id);
        return Ok(await handler.UpdateProductAsync(command, cancellationToken));
    }
    
    /// <summary>
    /// Delete a product by id.
    /// </summary>
    /// <param name="id"></param>
    /// <param name="handler"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [HttpDelete("{id:guid}")]
    public async Task<ActionResult> DeleteProduct(Guid id, [FromServices] ProductCommandHandler handler, CancellationToken cancellationToken)
    {
        await handler.DeleteProductAsync(id, cancellationToken);
        return NoContent();
    }
}