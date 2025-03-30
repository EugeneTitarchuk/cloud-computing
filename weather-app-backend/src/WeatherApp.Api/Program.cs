using FastEndpoints;
using FastEndpoints.Swagger;
using WeatherApp.Api.Models;
using WeatherApp.Api.Services;

var builder = WebApplication.CreateSlimBuilder(args);

builder.Services
    .AddFastEndpoints()
    .SwaggerDocument()
    .AddResponseCaching();

builder.Services.AddTransient<IWeatherForecastService, WeatherForecastService>();
builder.Services.Configure<ApplicationOptions>(builder.Configuration);

var app = builder.Build();

app.UseResponseCaching()
   .UseFastEndpoints()
   .UseSwaggerGen();

app.Run();


