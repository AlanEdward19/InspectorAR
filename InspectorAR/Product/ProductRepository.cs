using InspectorAR.Database;
using InspectorAR.Database.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace InspectorAR.Product;

/// <summary>
/// Repository for the Product entity.
/// </summary>
/// <param name="databaseDbContext"></param>
/// <param name="unitOfWork"></param>
public class ProductRepository(DatabaseDbContext databaseDbContext, IUnitOfWork unitOfWork) : IRepository<Entities.Product>
{
    /// <summary>
    /// Unit of work for the repository
    /// </summary>
    public IUnitOfWork UnitOfWork { get; } = unitOfWork;
    
    /// <summary>
    /// Adds a product to the database
    /// </summary>
    /// <param name="entity"></param>
    /// <param name="cancellationToken"></param>
    public async Task AddAsync(Entities.Product entity, CancellationToken cancellationToken)
    {
        await databaseDbContext.Products.AddAsync(entity, cancellationToken);
    }

    /// <summary>
    /// Updates a product in the database
    /// </summary>
    /// <param name="entity"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public Task UpdateAsync(Entities.Product entity, CancellationToken cancellationToken)
    {
        databaseDbContext.Products.Update(entity);
        return Task.CompletedTask;
    }

    /// <summary>
    /// Deletes a product from the database
    /// </summary>
    /// <param name="entity"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public Task DeleteAsync(Entities.Product entity, CancellationToken cancellationToken)
    {
        databaseDbContext.Products.Remove(entity);
        return Task.CompletedTask;
    }

    /// <summary>
    /// Gets a product from the database based on the id
    /// </summary>
    /// <param name="id"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public async Task<Entities.Product?> GetByIdAsync(Guid id, CancellationToken cancellationToken)
    {
        return await databaseDbContext.Products.FirstOrDefaultAsync(x => x.Id == id, cancellationToken);
    }
}