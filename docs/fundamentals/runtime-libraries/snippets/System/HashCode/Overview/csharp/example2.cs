// <Snippet1>
using System;
using System.Collections.Generic;

public struct Path1 : IEquatable<Path1>
{
    public IReadOnlyList<string> Segments { get; }

    public Path1(params string[] segments) => Segments = segments;

    public override bool Equals(object obj) => obj is Path1 o && Equals(o);

    public bool Equals(Path1 other)
    {
        if (ReferenceEquals(Segments, other.Segments)) return true;
        if (Segments is null || other.Segments is null) return false;
        if (Segments.Count != other.Segments.Count) return false;

        for (var i = 0; i < Segments.Count; i++)
        {
            if (!string.Equals(Segments[i], other.Segments[i]))
                return false;
        }

        return true;
    }

    public override int GetHashCode()
    {
        var hash = new HashCode();

        for (var i = 0; i < Segments?.Count; i++)
            hash.Add(Segments[i]);

        return hash.ToHashCode();
    }
}

class Program1
{
    static void Main(string[] args)
    {
        var set = new HashSet<Path1>
        {
            new Path1("C:", "tmp", "file.txt"),
            new Path1("C:", "tmp", "file.txt"),
            new Path1("C:", "tmp", "file.tmp")
        };

        Console.WriteLine($"Item count: {set.Count}.");
    }
}
// The example displays the following output:
// Item count: 2.
// </Snippet1>
