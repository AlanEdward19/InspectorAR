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

    /// <summary>
    /// Get all products on database
    /// </summary>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    /// <exception cref="InvalidOperationException"></exception>
    public async Task<List<ProductViewModel>> GetAllProductsAsync(CancellationToken cancellationToken)
    {
        logger.LogInformation("Getting all products");
        List<Entities.Product> products = await repository.GetAllAsync(cancellationToken) ?? throw new InvalidOperationException("There is no product in the database.");

        List<ProductViewModel> model = new List<ProductViewModel>();

        products.ForEach(product => model.Add(new(product.Id, product.Name, JsonSerializer.Deserialize<dynamic>(product.Information))));

        return model;
    }
}