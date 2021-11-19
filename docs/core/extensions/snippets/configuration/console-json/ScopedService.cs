using Microsoft.Extensions.Options;

namespace ConsoleJson.Example;

public class ScopedService
{
    private readonly TransientFaultHandlingOptions _options;

    public ScopedService(IOptionsSnapshot<TransientFaultHandlingOptions> options) =>
        _options = options.Value;

    public void DisplayValues()
    {
        Console.WriteLine($"TransientFaultHandlingOptions.Enabled={_options.Enabled}");
        Console.WriteLine($"TransientFaultHandlingOptions.AutoRetryDelay={_options.AutoRetryDelay}");
    }
}
