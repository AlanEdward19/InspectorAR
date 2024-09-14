using System.Text.Json;
using InspectorAR.Database.Interfaces;
using InspectorAR.Product.Common.Models;

namespace InspectorAR.Product.Common.Handlers;

/// <summary>
/// Handles the queries related to products
/// </summary>
/// <param name="logger"></param>
/// <param name="repository"></param>
public class ProductQueryHandler(ILogger<ProductCommandHandler> logger, IRepository<Entities.Product> repository)
{
    /// <summary>
    /// Get a product based on the id
    /// </summary>
    /// <param name="id"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    /// <exception cref="InvalidOperationException"></exception>
    public async Task<ProductViewModel> GetProductAsync(Guid id, CancellationToken cancellationToken)
    {
        logger.LogInformation("Getting product with id {id}", id);
        Entities.Product product = await repository.GetByIdAsync(id, cancellationToken) ?? throw new InvalidOperationException("Product not found with the given id");

        return new (product.Id, product.Name, JsonSerializer.Deserialize<dynamic>(product.Information));
    }
}