using AutoMapper;
using Candidate.Common;
using Candidate.Web.Infrastructure;

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
builder.Services.AddControllers();
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

app.UseStaticFiles();

app.MapRazorPages();

app.Run();
