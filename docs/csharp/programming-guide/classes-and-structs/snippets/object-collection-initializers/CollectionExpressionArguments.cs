namespace object_collection_initializers;

public class CollectionExpressionArguments
{
    public static void Main(string[] args)
    {
        Console.WriteLine("Testing Collection Expression with Arguments:");
        Console.WriteLine("==========================================");

        CollectionExpressionWithArgumentsExample();

        Console.WriteLine("\nDemonstration completed successfully!");
    }

    // <SnippetCollectionExpressionWithArguments>
    public static void CollectionExpressionWithArgumentsExample()
    {
        string[] values = ["one", "two", "three"];

        // Use with() to pass capacity to the List<T> constructor
        List<string> names = [with(capacity: values.Length * 2), .. values];

        Console.WriteLine($"Created List<string> with capacity: {names.Capacity}");
        Console.WriteLine($"List contains {names.Count} elements: [{string.Join(", ", names)}]");

        // Use with() to pass a comparer to the HashSet<T> constructor
        HashSet<string> caseInsensitiveSet = [with(StringComparer.OrdinalIgnoreCase), "Hello", "HELLO"];
        // caseInsensitiveSet contains only one element because "Hello" and "HELLO" are equal

        Console.WriteLine($"HashSet with case-insensitive comparer contains {caseInsensitiveSet.Count} elements: [{string.Join(", ", caseInsensitiveSet)}]");
        Console.WriteLine("Note: 'Hello' and 'HELLO' are treated as the same element due to OrdinalIgnoreCase comparer");
    }
    // </SnippetCollectionExpressionWithArguments>
}
