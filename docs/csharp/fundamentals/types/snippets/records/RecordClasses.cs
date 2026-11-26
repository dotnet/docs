namespace RecordClassDemo;

// <PositionalRecordClass>
public record Route(string Start, string End);
// </PositionalRecordClass>

// <ReferenceMemberRecord>
public record Reading(string Station, int[] Samples);
// </ReferenceMemberRecord>

public static class Program
{
    public static void Main()
    {
        // <RecordClassEquality>
        var outward = new Route("North", "South");
        var sameRoute = new Route("North", "South");

        Console.WriteLine(outward == sameRoute); // => True
        Console.WriteLine(ReferenceEquals(outward, sameRoute)); // => False
        Console.WriteLine(outward); // => Route { Start = North, End = South }
        // </RecordClassEquality>

        // <RecordClassDeconstruction>
        var (start, end) = outward;
        Console.WriteLine($"{start} to {end}"); // => North to South
        // </RecordClassDeconstruction>

        // <RecordClassWith>
        var changed = outward with { End = "West" };
        Console.WriteLine(outward.End); // => South
        Console.WriteLine(changed.End); // => West
        Console.WriteLine(outward == changed); // => False
        // </RecordClassWith>

        // <ShallowRecordClassCopy>
        var original = new Reading("North", new[] { 10, 20 });
        var alias = original;
        var copy = original with { };

        Console.WriteLine(ReferenceEquals(original, alias)); // => True
        Console.WriteLine(ReferenceEquals(original, copy)); // => False
        Console.WriteLine(original == copy); // => True
        Console.WriteLine(ReferenceEquals(original.Samples, copy.Samples)); // => True

        copy.Samples[0] = 99;
        Console.WriteLine(original.Samples[0]); // => 99
        Console.WriteLine(alias.Samples[0]); // => 99
        Console.WriteLine(original == copy); // => True
        // </ShallowRecordClassCopy>

        // <RecordClassArrayEquality>
        var separate = new Reading("North", new[] { 99, 20 });
        Console.WriteLine(original == separate); // => False
        // </RecordClassArrayEquality>

#if INIT_ONLY
        original.Station = "West";
#endif
    }
}
