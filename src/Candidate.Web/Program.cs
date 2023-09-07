using AutoMapper;
using Candidate.Common;
using Candidate.Web.Infrastructure;
using Microsoft.AspNetCore.SpaServices.AngularCli;

var builder = WebApplication.CreateBuilder(args);

ConfigurationManager configuration = builder.Configuration;
IWebHostEnvironment environment = builder.Environment;

var configRoot = new
{
    AppSettings = new AppSettings()
};

configuration.Bind(configRoot);

// Add services to the container.
builder.Services.RegisterDependency(configRoot.AppSettings);

builder.Services.AddAuthentication(ApiKeyAuthenticationOptions.DefaultScheme).AddScheme<ApiKeyAuthenticationOptions, ApiKeyAuthenticationHandler>(ApiKeyAuthenticationOptions.DefaultScheme, null); ;
builder.Services.AddControllers();
builder.Services.AddMemoryCache();
builder.Services.AddCors(options =>
{
    options.AddPolicy("CorsPolicy", builder => builder.WithOrigins("http://localhost:4200/")
    .AllowAnyMethod()
    .AllowAnyHeader()
    .AllowCredentials());
});

builder.Services.AddSingleton(provider => new MapperConfiguration(cfg =>
{
    cfg.AddProfile(new AutoMapperConfig());
}).CreateMapper());

// Add services to the container.
builder.Services.AddRazorPages();

builder.Services.AddSpaStaticFiles(configuration =>
{
    configuration.RootPath = "ClientApp/dist/candidates";
});
var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseCors(x => x
                   .AllowAnyMethod()
                   .AllowAnyHeader()
                   .WithHeaders()
                   .AllowCredentials()
                   .SetIsOriginAllowed(origin =>
                   true));
}

app.UseCors("CorsPolicy");

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.UseHttpsRedirection();
if (!app.Environment.IsDevelopment())
{
    app.UseSpaStaticFiles();
}
app.UseStaticFiles();

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllerRoute(
        name: "default",
        pattern: "{controller}/{action=Index}/{id?}");
    endpoints.MapControllers();
});

app.UseSpa(spa =>
{
    spa.Options.SourcePath = "ClientApp";

    if (app.Environment.IsDevelopment())
    {
        spa.UseAngularCliServer(npmScript: "start");
    }
});

app.Run();
