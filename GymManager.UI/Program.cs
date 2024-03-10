using GymManager.Infrastructure;
using GymManager.Application;
using NLog.Web;
using GymManager.UI.Extension;
using GymManager.UI.Middlewares;
using System.Globalization;

var builder = WebApplication.CreateBuilder(args);

builder.Logging.ClearProviders();
builder.Logging.SetMinimumLevel(LogLevel.Information);
builder.Logging.AddNLogWeb();

builder.Services.AddCultures();

builder.Services.AddApplication();
builder.Services.AddInfrastructure();
builder.Services.DefinedViewLocation(builder.Configuration);

builder.Services.AddControllersWithViews();

var app = builder.Build();

app.UseInfrastructure();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseMiddleware<ExceptionHandlerMiddleware>();

var logger = app.Services.GetService<ILogger<Program>>();
if (app.Environment.IsDevelopment())
{
    logger.LogInformation("DEVELOPMENT MODE!!!");
}
else
{
    logger.LogInformation("PRODUCTION MODE!!!");
}
app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
