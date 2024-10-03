using System;

internal class Spans
{
    public static bool RunIt()
    {
        // <StartsWith>
        ReadOnlySpan<char> text = "some arbitrary text";
        return text.StartsWith('"') && text.EndsWith('"'); // false
        // </StartsWith>
    }
}
