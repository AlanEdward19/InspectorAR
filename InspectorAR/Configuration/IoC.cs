
using InspectorAR.Database;
using InspectorAR.Database.Interfaces;
using InspectorAR.Product;
using InspectorAR.Product.Common.Handlers;
using Microsoft.EntityFrameworkCore;

namespace InspectorAR.Configuration;

/// <summary>
/// IoC configuration
/// </summary>
public static class IoC
{
    /// <summary>
    /// Configures the IoC
    /// </summary>
    /// <param name="services"></param>
    /// <returns></returns>
    public static IServiceCollection ConfigureIoC(this IServiceCollection services, IConfiguration configuration)
    {
        services
            .ConfigureDatabase(configuration)
            .ConfigureRepositories()
            .ConfigureHandlers();

        return services;
    }
    
    /// <summary>
    /// Configures the repositories
    /// </summary>
    /// <param name="services"></param>
    /// <returns></returns>
    private static IServiceCollection ConfigureRepositories(this IServiceCollection services)
    {
        services.AddScoped<IRepository<Product.Entities.Product>, ProductRepository>();

        return services;
    }
    
    /// <summary>
    /// Configures the handlers
    /// </summary>
    /// <param name="services"></param>
    /// <returns></returns>
    private static IServiceCollection ConfigureHandlers(this IServiceCollection services)
    {
        services.AddScoped<ProductCommandHandler>();
        services.AddScoped<ProductQueryHandler>();

        return services;
    }
    
    /// <summary>
    /// Configures the database
    /// </summary>
    /// <param name="services"></param>
    /// <param name="configuration"></param>
    /// <returns></returns>
    private static IServiceCollection ConfigureDatabase(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<DatabaseDbContext>(options =>
            options.UseSqlServer(configuration.GetConnectionString("MainDatabase")));

        services.AddScoped<IUnitOfWork, UnitOfWork>();

        return services;
    }
}