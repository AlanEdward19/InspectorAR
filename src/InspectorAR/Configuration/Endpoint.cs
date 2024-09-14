namespace InspectorAR.Configuration;

/// <summary>
/// Endpoint configuration.
/// </summary>
public static class Endpoint
{
    /// <summary>
    /// Endpoint configuration.
    /// </summary>
    /// <param name="app"></param>
    /// <param name="section"></param>
    /// <returns></returns>
    public static IApplicationBuilder ConfigureEndpoints(this IApplicationBuilder app, IConfigurationSection section)
    {
        var apiHealthCheckUrl = section["APIHealthCheckUrl"];

        app
            .UseRouting()
            .UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
                endpoints.MapHealthChecks(apiHealthCheckUrl!);
            });

        return app;
    }
}