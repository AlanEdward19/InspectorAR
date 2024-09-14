using System.ComponentModel;
using Microsoft.OpenApi.Models;

namespace InspectorAR.Configuration;

/// <summary>
/// Swagger configuration
/// </summary>
public static class Swagger
{
    /// <summary>
    /// Configure swagger
    /// </summary>
    /// <param name="services"></param>
    /// <returns></returns>
    public static IServiceCollection ConfigureSwagger(this IServiceCollection services)
    {
        services
            .AddEndpointsApiExplorer()
            .AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "InspectorAR.API",
                    Version = "v1",
                    Description = """
                                  InspectorAR é uma API Restful para gerenciamento de produtos. Onde podemos adicionar, atualizar, deletar e listar produtos.
                                  """
                });
                
                c.CustomSchemaIds(x =>
                    x.GetCustomAttributes(false).OfType<DisplayNameAttribute>().FirstOrDefault()?.DisplayName ??
                    x.Name);

#if DEBUG
                Directory.GetFiles("./Configuration/Comments/", "*.xml", SearchOption.TopDirectoryOnly).ToList()
                    .ForEach(xml => c.IncludeXmlComments(xml));
#endif

            });

        return services;
    }
}