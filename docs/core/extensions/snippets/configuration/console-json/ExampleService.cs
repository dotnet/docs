using Microsoft.Extensions.Options;

namespace ConsoleJson.Example;

public sealed class ExampleService(IOptions<TransientFaultHandlingOptions> options)
{
    private readonly TransientFaultHandlingOptions _options = options.Value;

    public void DisplayValues()
    {
        Console.WriteLine($"TransientFaultHandlingOptions.Enabled={_options.Enabled}");
        Console.WriteLine($"TransientFaultHandlingOptions.AutoRetryDelay={_options.AutoRetryDelay}");
    }
}
