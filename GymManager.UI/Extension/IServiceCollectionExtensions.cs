using Microsoft.AspNetCore.Mvc.Razor;
using System.Globalization;

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

    public static void AddCultures(this IServiceCollection service)
    {
        var supportedCultures = new List<CultureInfo>
        {
            new CultureInfo("pl"),
            new CultureInfo("en")
        };

        CultureInfo.DefaultThreadCurrentCulture = supportedCultures[0];
        CultureInfo.DefaultThreadCurrentUICulture = supportedCultures[1];
        service.Configure<RequestLocalizationOptions>(options =>
        {
            options.DefaultRequestCulture = new Microsoft.AspNetCore.Localization.RequestCulture(supportedCultures[0]);
            options.SupportedCultures = supportedCultures;
            options.SupportedUICultures = supportedCultures;
        });
    }
}
