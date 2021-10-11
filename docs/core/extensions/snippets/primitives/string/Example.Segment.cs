using System;
using Microsoft.Extensions.Primitives;

public partial class Example
{
    public void RunSegments()
    {
        var segment =
            new StringSegment(
                "This a string, within a single segment representation.",
                14, 25);

        Console.WriteLine($"Buffer: \"{segment.Buffer}\"");
        Console.WriteLine($"Offset: {segment.Offset}");
        Console.WriteLine($"Length: {segment.Length}");
        Console.WriteLine($"Value: \"{segment.Value}\"");

        Console.WriteLine($"StartsWith \" \": {segment.StartsWith(" ", StringComparison.OrdinalIgnoreCase)}");
        Console.WriteLine($"EndsWith \" \": {segment.EndsWith(" ", StringComparison.OrdinalIgnoreCase)}");
    }
}
