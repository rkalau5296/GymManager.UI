using Microsoft.AspNetCore.Mvc.Razor;

namespace GymManager.UI.Extension;

public static class IServiceCollectionExtensions
{
    public static void DefinedViewLocation(this IServiceCollection services, IConfiguration configuration)
    {
        var templateKey = configuration.GetSection("TemplateKey").Value;
        services.Configure<RazorViewEngineOptions>(x =>
        {
            x.ViewLocationFormats.Clear();
            if (templateKey != "Basic")
            {
                x.ViewLocationFormats.Add("/Views/" + templateKey + "/{1}/{0}" + RazorViewEngine.ViewExtension);
                x.ViewLocationFormats.Add("/Views/" + templateKey + "/Shared/{0}" + RazorViewEngine.ViewExtension);
            }
            x.ViewLocationFormats.Add("/Views/Basic/{1}/{0}" + RazorViewEngine.ViewExtension);
            x.ViewLocationFormats.Add("/Views/Basic/Shared/{0}" + RazorViewEngine.ViewExtension);
        });
    }
}
