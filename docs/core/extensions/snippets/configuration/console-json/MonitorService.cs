using Microsoft.Extensions.Options;

namespace ConsoleJson.Example;

public class MonitorService
{
    private readonly IOptionsMonitor<TransientFaultHandlingOptions> _monitor;

    public MonitorService(IOptionsMonitor<TransientFaultHandlingOptions> monitor) =>
        _monitor = monitor;

    public void DisplayValues()
    {
        TransientFaultHandlingOptions options = _monitor.CurrentValue;

        Console.WriteLine($"TransientFaultHandlingOptions.Enabled={options.Enabled}");
        Console.WriteLine($"TransientFaultHandlingOptions.AutoRetryDelay={options.AutoRetryDelay}");
    }
}
