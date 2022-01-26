using System;
using Microsoft.Extensions.Primitives;

public partial class Example
{
    public void RunSegments()
    {
        // <Segment>
        var segment =
            new StringSegment(
                "This a string, within a single segment representation.",
                14, 25);

        Console.WriteLine($"Buffer: \"{segment.Buffer}\"");
        Console.WriteLine($"Offset: {segment.Offset}");
        Console.WriteLine($"Length: {segment.Length}");
        Console.WriteLine($"Value: \"{segment.Value}\"");

        Console.Write("Span: \"");
        foreach (char @char in segment.AsSpan())
        {
            Console.Write(@char);
        }
        Console.Write("\"\n");

        // Outputs:
        //     Buffer: "This a string, within a single segment representation."
        //     Offset: 14
        //     Length: 25
        //     Value: " within a single segment "
        //     " within a single segment "
        // </Segment>
    }
}
