using AutofacTest.Services.ServiceOne;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace AutofacTest.Services;

public class Service3 : IHostedService
{
    public required ILogger<Service3> Logger { protected get; init; }
    public required Service1 Service1 { get; init; }
    public required Service2 Service2 { get; init; }


    public Task StartAsync(CancellationToken cancellationToken)
    {
        Logger.LogInformation("Hello from service 3!");
        Service1.Test();
        Service2.Test();
        return Task.CompletedTask;
    }

    public Task StopAsync(CancellationToken cancellationToken)
    {
        return Task.CompletedTask;
    }
}