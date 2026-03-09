using System.Buffers;

namespace ExampleCode;

internal partial class DemoCode
{
    private static readonly SearchValues<string> Commands =
        SearchValues.Create(
            ["start", "run", "go", "begin", "commence"],
            StringComparison.OrdinalIgnoreCase);

    void ProcessCommand(string command)
    {
        if (Commands.Contains(command))
        {
            // ...
        }
    }
}
