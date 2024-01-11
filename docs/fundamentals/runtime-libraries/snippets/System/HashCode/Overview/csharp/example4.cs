// <Snippet1>
using System;
using System.Collections.Generic;

public struct Path2 : IEquatable<Path2>
{
    public IReadOnlyList<string> Segments { get; }

    public Path2(params string[] segments) => Segments = segments;

    public override bool Equals(object obj) => obj is Path2 o && Equals(o);

    public bool Equals(Path2 other)
    {
        if (ReferenceEquals(Segments, other.Segments)) return true;
        if (Segments is null || other.Segments is null) return false;
        if (Segments.Count != other.Segments.Count) return false;

        for (var i = 0; i < Segments.Count; i++)
        {
            if (!PlatformUtils.Path2Equals(Segments[i], other.Segments[i]))
                return false;
        }

        return true;
    }

    public override int GetHashCode()
    {
        var hash = new HashCode();

        for (var i = 0; i < Segments?.Count; i++)
            PlatformUtils.AddPath2(ref hash, Segments[i]);

        return hash.ToHashCode();
    }
}

internal static class PlatformUtils
{
    public static bool Path2Equals(string a, string b) => string.Equals(a, b, StringComparison.OrdinalIgnoreCase);
    public static void AddPath2(ref HashCode hash, string Path2) => hash.Add(Path2, StringComparer.OrdinalIgnoreCase);
}

class Program4
{
    static void Main(string[] args)
    {
        var set = new HashSet<Path2>
        {
            new Path2("C:", "tmp", "file.txt"),
            new Path2("C:", "TMP", "file.txt"),
            new Path2("C:", "tmp", "FILE.TXT")
        };

        Console.WriteLine($"Item count: {set.Count}.");
    }
}
// The example displays the following output:
// Item count: 1.
// </Snippet1>
