using Autofac;
using AutofacTest.Helpers;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;

namespace AutofacTest.Services.ServiceOne;

public class Service1Module : Module
{
    private IConfiguration _configuration;

    public Service1Module(IConfiguration configuration)
    {
        _configuration = configuration ?? throw new ArgumentNullException(nameof(configuration));
    }

    protected override void Load(ContainerBuilder builder)
    {
        builder.RegisterType<Service1>().AsSelf().As<IHostedService>().SingleInstance().PropertiesAutowired();
        builder.ConfigureWithValidation<Service1Options>(
            _configuration.GetExistingSectionOrThrow(Service1Options.Name));
    }
}