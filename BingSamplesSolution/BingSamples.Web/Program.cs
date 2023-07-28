using BingSamples.Web.Core;
using BingSamples.Web.Options;
using BingSamples.Web.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddOptions<AppOptions>()
    .Bind(builder.Configuration.GetSection(WebConstants.AppOptionsSectionName))
    .ValidateDataAnnotations()
    .ValidateOnStart();

builder.Services.AddHealthChecks();
builder.Services.AddRazorPages().AddRazorPagesOptions(options =>
    options.Conventions.AddPageRoute("/Info/Index", ""));

builder.Services.AddHttpClient<BingTranslatorService>();
builder.Services.AddHttpClient<BingSearchService>();

var app = builder.Build();

if (!app.Environment.IsDevelopment()) app.UseExceptionHandler("/Info/Error");

app.UseStaticFiles();
app.UseRouting();
app.UseAuthorization();
app.UseEndpoints(endpoints =>
{
    endpoints.MapHealthChecks("/health").AllowAnonymous();
    endpoints.MapRazorPages();
});
app.Run();