using Microsoft.EntityFrameworkCore;

namespace InspectorAR.Database;

/// <summary>
/// Database context for InspectorAR.
/// </summary>
/// <param name="options"></param>
public class DatabaseDbContext(DbContextOptions<DatabaseDbContext> options) : DbContext(options)
{
    #region DbSets

    /// <summary>
    /// Products table.
    /// </summary>
    public DbSet<Product.Entities.Product> Products { get; set; }

    #endregion
}