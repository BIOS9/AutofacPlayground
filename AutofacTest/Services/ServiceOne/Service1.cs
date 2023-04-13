using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace AutofacTest.Services.ServiceOne;

public class Service1 : IHostedService
{
    public required ILogger<Service1> Logger { protected get; init; }
    public required Service2 Service2 { protected get; init; }

    public required IOptions<Service1Options> Options { protected get; init; }

    public void Test()
    {
        Logger.LogInformation("Test from service 1 {Thing}!", Options.Value.Thing);
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