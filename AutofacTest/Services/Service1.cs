using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace AutofacTest.Services;

public class Service1 : IHostedService
{
    public required ILogger<Service1> Logger { protected get; init; }
    public required Service2 Service2 { get; init; }


    public void Test()
    {
        Logger.LogInformation("Test from service 1!");
    }
    

    public Task StartAsync(CancellationToken cancellationToken)
    {
        Logger.LogInformation("Hello from service 1!");
        Service2.Test();
        return Task.CompletedTask;
    }

    public Task StopAsync(CancellationToken cancellationToken)
    {
        return Task.CompletedTask;
    }
}