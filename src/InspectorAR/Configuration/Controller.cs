using System.Text.Json;
using System.Text.Json.Serialization;
using FluentValidation;
using FluentValidation.AspNetCore;
using InspectorAR.Product.AddProduct;

namespace InspectorAR.Configuration;

/// <summary>
/// Configures the controller
/// </summary>
public static class Controller
{
    /// <summary>
    /// Configures the controller
    /// </summary>
    /// <param name="services"></param>
    /// <returns></returns>
    public static IServiceCollection ConfigureController(this IServiceCollection services)
    {
        services.AddControllers().AddJsonOptions(options =>
        {
            options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
            options.JsonSerializerOptions.DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull;
            options.JsonSerializerOptions.PropertyNamingPolicy = JsonNamingPolicy.CamelCase;
        });

        services.AddFluentValidationAutoValidation();
        services.AddFluentValidationClientsideAdapters();
        services.AddValidatorsFromAssemblyContaining<AddProductCommandValidator>();
        ValidatorOptions.Global.DefaultClassLevelCascadeMode = CascadeMode.Stop;

        return services;
    }
}