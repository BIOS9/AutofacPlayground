using Autofac.Extensions.DependencyInjection;
using AutofacTest;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Serilog;

await Host.CreateDefaultBuilder(args)
    .ConfigureAppConfiguration(config =>
    {
        config.AddEnvironmentVariables();
        config.AddUserSecrets<Program>();
    })
    .UseSerilog((context, config) =>
    {
        config.WriteTo.Console();
    })
    .ConfigureServices((context, services) =>
    {
        services
            .AddAutofac()
            .AddHostedService<Startup>();
    })
    .Build()
    .RunAsync();