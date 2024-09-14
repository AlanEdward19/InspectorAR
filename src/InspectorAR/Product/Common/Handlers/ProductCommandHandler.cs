using System.Text.Json;
using InspectorAR.Database.Interfaces;
using InspectorAR.Product.AddProduct;
using InspectorAR.Product.Common.Models;
using InspectorAR.Product.UpdateProduct;

namespace InspectorAR.Product.Common.Handlers;

/// <summary>
/// Handles the commands related to products
/// </summary>
/// <param name="logger"></param>
/// <param name="repository"></param>
public class ProductCommandHandler(ILogger<ProductCommandHandler> logger, IRepository<Entities.Product> repository)
{
    /// <summary>
    /// Add a product based on the command
    /// </summary>
    /// <param name="command"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public async Task<ProductViewModel> AddProductAsync(AddProductCommand command, CancellationToken cancellationToken)
    {
        logger.LogInformation("Adding product with name {name}", command.Name);

        await repository.UnitOfWork.StartAsync(cancellationToken);
        
        var product = new Entities.Product(command.Name!, JsonSerializer.Serialize(command.Information));
        
        await repository.AddAsync(product, cancellationToken);
        
        await repository.UnitOfWork.SaveEntitiesAsync(cancellationToken);
        await repository.UnitOfWork.CommitAsync(cancellationToken);
        
        return new (product.Id, product.Name, JsonSerializer.Deserialize<dynamic>(product.Information));
    }
    
    /// <summary>
    /// Update a product based on the command
    /// </summary>
    /// <param name="command"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public async Task<ProductViewModel> UpdateProductAsync(UpdateProductCommand command, CancellationToken cancellationToken)
    {
        logger.LogInformation("Updating product with id {id}", command.Id);
        
        await repository.UnitOfWork.StartAsync(cancellationToken);
        
        Entities.Product product = await repository.GetByIdAsync(command.Id, cancellationToken) ?? throw new InvalidOperationException("Product not found with the given id");
        
        product.UpdateBasedOnCommand(command);
        
        await repository.UpdateAsync(product, cancellationToken);
        
        await repository.UnitOfWork.SaveEntitiesAsync(cancellationToken);
        await repository.UnitOfWork.CommitAsync(cancellationToken);
        
        return new (product.Id, product.Name, JsonSerializer.Deserialize<dynamic>(product.Information));
    }
    
    /// <summary>
    /// Delete a product based on the id
    /// </summary>
    /// <param name="id"></param>
    /// <param name="cancellationToken"></param>
    /// <exception cref="InvalidOperationException"></exception>
    public async Task DeleteProductAsync(Guid id, CancellationToken cancellationToken)
    {
        logger.LogInformation("Deleting product with id {id}", id);
        
        await repository.UnitOfWork.StartAsync(cancellationToken);
        
        Entities.Product product = await repository.GetByIdAsync(id, cancellationToken) ?? throw new InvalidOperationException("Product not found with the given id");
        
        await repository.DeleteAsync(product, cancellationToken);
        
        await repository.UnitOfWork.SaveEntitiesAsync(cancellationToken);
        await repository.UnitOfWork.CommitAsync(cancellationToken);
    }
}