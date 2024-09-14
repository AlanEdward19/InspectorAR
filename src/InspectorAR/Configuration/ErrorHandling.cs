using InspectorAR.Middleware;

namespace InspectorAR.Configuration;

/// <summary>
/// Error handling configuration.
/// </summary>
public static class ErrorHandling
{
    /// <summary>
    /// Middleware configuration.
    /// </summary>
    /// <param name="app"></param>
    /// <returns></returns>
    public static IApplicationBuilder ConfigureMiddleware(this IApplicationBuilder app)
    {
        app.UseMiddleware<ExceptionMiddleware>();

        return app;
    }
}