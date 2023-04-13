using Autofac;
using Autofac.Extensions.DependencyInjection;
using AutofacTest.Helpers;
using AutofacTest.Services;
using AutofacTest.Services.ServiceOne;
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
    .ConfigureContainer<ContainerBuilder>((context, builder) =>
    {

        IConfigurationSection s1Options = context.Configuration.GetExistingSectionOrThrow(Service1Options.Name);
        
        builder.RegisterType<Service1>().AsSelf().As<IHostedService>().SingleInstance().PropertiesAutowired();
        builder.RegisterType<Service2>().PropertiesAutowired();
        builder.RegisterType<Service3>().As<IHostedService>().SingleInstance().PropertiesAutowired();
        builder.ConfigureWithValidation<Service1Options>(s1Options);
    })
    .Build()
    .RunAsync();