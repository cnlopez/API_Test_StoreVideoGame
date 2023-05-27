using Swashbuckle.AspNetCore.SwaggerGen;
using System.Reflection;

namespace API_Test_Store.Extensions;

public static class SwaggerGenOptionsExtensions
{
    /// <summary>
    /// Set the comments path for the Swagger JSON and UI.
    /// Xml documentation needs to be enabled in the project.
    /// </summary>
    /// <param name="swaggerGenOptions"></param>
    public static void IncludeLocalXmlComments(this SwaggerGenOptions swaggerGenOptions)
    {
        var xmlFile = $"{Assembly.GetEntryAssembly()!.GetName().Name}.xml";
        var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
        swaggerGenOptions.IncludeXmlComments(xmlPath);
    }
}