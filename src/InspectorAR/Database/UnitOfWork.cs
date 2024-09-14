using InspectorAR.Database.Interfaces;

namespace InspectorAR.Database;

/// <summary>
/// Unit of work implementation.
/// </summary>
/// <param name="databaseDbContext"></param>
public class UnitOfWork(DatabaseDbContext databaseDbContext) : IUnitOfWork
{
    /// <summary>
    /// Save entities in database.
    /// </summary>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public async Task<bool> SaveEntitiesAsync(CancellationToken cancellationToken)
    {
        return await databaseDbContext.SaveChangesAsync(cancellationToken) != 0;
    }

    /// <summary>
    /// Start transaction.
    /// </summary>
    /// <param name="cancellationToken"></param>
    public async Task StartAsync(CancellationToken cancellationToken)
    {
        await databaseDbContext.Database.BeginTransactionAsync(cancellationToken);
    }

    /// <summary>
    /// Commit transaction.
    /// </summary>
    /// <param name="cancellationToken"></param>
    public async Task CommitAsync(CancellationToken cancellationToken)
    {
        await databaseDbContext.Database.CommitTransactionAsync(cancellationToken);
    }

    /// <summary>
    /// Rollback transaction.
    /// </summary>
    /// <param name="cancellationToken"></param>
    public async Task RollbackAsync(CancellationToken cancellationToken)
    {
        await databaseDbContext.Database.RollbackTransactionAsync(cancellationToken);
    }
}