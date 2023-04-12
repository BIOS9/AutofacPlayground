using Microsoft.Extensions.Logging;

namespace AutofacTest.Services;

public class Service2
{
    public required ILogger<Service2> Logger { protected get; init; }

    public void Test()
    {
        Logger.LogInformation("Hello from service 2!");
    }
}