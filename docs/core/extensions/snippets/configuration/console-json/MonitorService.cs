using Microsoft.Extensions.Options;

namespace ConsoleJson.Example;

public sealed class MonitorService(IOptionsMonitor<TransientFaultHandlingOptions> monitor)
{
    public void DisplayValues()
    {
        TransientFaultHandlingOptions options = monitor.CurrentValue;

        Console.WriteLine($"TransientFaultHandlingOptions.Enabled={options.Enabled}");
        Console.WriteLine($"TransientFaultHandlingOptions.AutoRetryDelay={options.AutoRetryDelay}");
    }
}
