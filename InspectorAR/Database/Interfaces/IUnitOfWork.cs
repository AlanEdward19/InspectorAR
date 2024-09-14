namespace InspectorAR.Database.Interfaces;

/// <summary>
/// Unit of Work interface.
/// </summary>
public interface IUnitOfWork
{
    /// <summary>
    /// Save entities async.
    /// </summary>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    Task<bool> SaveEntitiesAsync(CancellationToken cancellationToken);
    
    /// <summary>
    /// Start transaction async.
    /// </summary>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    Task StartAsync(CancellationToken cancellationToken);
    
    /// <summary>
    /// Commit transaction async.
    /// </summary>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    Task CommitAsync(CancellationToken cancellationToken);
    
    /// <summary>
    /// Rollback transaction async.
    /// </summary>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    Task RollbackAsync(CancellationToken cancellationToken);
}