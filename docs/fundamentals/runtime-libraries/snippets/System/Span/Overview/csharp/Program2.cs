using System;

class Program2
{
    static void Run()
    {
        string contentLength = "Content-Length: 132";
        int length = GetContentLength(contentLength.ToCharArray());
        Console.WriteLine($"Content length: {length}");
    }

    private static int GetContentLength(ReadOnlySpan<char> span)
    {
        ReadOnlySpan<char> slice = span.Slice(16);
        return int.Parse(slice);
    }
}

// Output:
//      Content length: 132
