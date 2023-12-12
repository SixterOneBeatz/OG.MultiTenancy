using OG.Multitenancy.API;

var builder = WebApplication.CreateBuilder(args);

var configuration = builder.Configuration;

builder.Services.ConfigureServices(configuration);

var app = builder.Build();

app.Configure();
