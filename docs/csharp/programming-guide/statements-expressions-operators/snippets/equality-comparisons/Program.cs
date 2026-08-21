namespace EqualityComparisons;

public static class Program
{
    public static void Main()
    {
        var first = new Sample { Number = 1, Text = "Hi" };
        var second = new Sample { Number = 1, Text = "Hi" };

        Console.WriteLine(ReferenceEquals(first, second)); // => False

        second = first;

        Console.WriteLine(ReferenceEquals(first, second)); // => True
    }

    private sealed class Sample
    {
        public int Number { get; init; }
        public required string Text { get; init; }
    }
}
