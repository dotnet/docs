using Microsoft.Extensions.Options;

namespace ConsoleJson.Example;

public class ExampleService
{
    private readonly TransientFaultHandlingOptions _options;

    public ExampleService(IOptions<TransientFaultHandlingOptions> options) =>
        _options = options.Value;

    public void DisplayValues()
    {
        Console.WriteLine($"TransientFaultHandlingOptions.Enabled={_options.Enabled}");
        Console.WriteLine($"TransientFaultHandlingOptions.AutoRetryDelay={_options.AutoRetryDelay}");
    }
}
