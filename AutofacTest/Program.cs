using Autofac;
using Autofac.Extensions.DependencyInjection;
using AutofacTest;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Serilog;

await Host.CreateDefaultBuilder(args)
    .ConfigureAppConfiguration(config =>
    {
        config.AddEnvironmentVariables();
        config.AddUserSecrets<Program>();
    })
    .UseServiceProviderFactory(new AutofacServiceProviderFactory())
    .UseSerilog((context, config) => config.ReadFrom.Configuration(context.Configuration))
    .ConfigureContainer<ContainerBuilder>(builder =>
    {
        builder.RegisterType<Startup>().As<IHostedService>().SingleInstance();
    })
    .Build()
    .RunAsync();