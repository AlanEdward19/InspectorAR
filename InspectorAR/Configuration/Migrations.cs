using InspectorAR.Database;
using Microsoft.EntityFrameworkCore;

namespace InspectorAR.Configuration;

/// <summary>
/// Configuration for migrations.
/// </summary>
public static class Migrations
{
    /// <summary>
    /// Update migrations.
    /// </summary>
    /// <param name="app"></param>
    /// <returns></returns>
    /// <exception cref="Exception"></exception>
    public static IApplicationBuilder UpdateMigrations(this IApplicationBuilder app)
    {
        using var serviceScope = app.ApplicationServices.GetService<IServiceScopeFactory>()?.CreateScope();

        var context = serviceScope?.ServiceProvider.GetRequiredService<DatabaseDbContext>();

        if (context != null)
        {
            try
            {
                var pendingMigrations = context.Database.GetPendingMigrations();
                if (pendingMigrations != null && pendingMigrations.Any())
                {
                    context.Database.Migrate();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        return app;
    }
}