// <Snippet1>
using System;
using System.Collections.Generic;

public struct Path : IEquatable<Path>
{
    public IReadOnlyList<string> Segments { get; }

    public Path(params string[] segments) => Segments = segments;

    public override bool Equals(object obj) => obj is Path o && Equals(o);

    public bool Equals(Path other)
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

class Program
{
    static void Main(string[] args)
    {
        var set = new HashSet<Path>
        {
            new Path("C:", "tmp", "file.txt"),
            new Path("C:", "tmp", "file.txt"),
            new Path("C:", "tmp", "file.tmp")
        };

        Console.WriteLine($"Item count: {set.Count}.");
    }
}
// The example displays the following output:
// Item count: 2.
// </Snippet1>