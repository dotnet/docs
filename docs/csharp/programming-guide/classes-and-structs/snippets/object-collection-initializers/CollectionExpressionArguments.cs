namespace object_collection_initializers;

public class CollectionExpressionArguments
{
    // <SnippetCollectionExpressionWithArguments>
    public static void CollectionExpressionWithArgumentsExample()
    {
        string[] values = ["one", "two", "three"];

        // Use with() to pass capacity to the List<T> constructor
        List<string> names = [with(capacity: values.Length * 2), .. values];

        // Use with() to pass a comparer to the HashSet<T> constructor
        HashSet<string> caseInsensitiveSet = [with(StringComparer.OrdinalIgnoreCase), "Hello", "HELLO"];
        // caseInsensitiveSet contains only one element because "Hello" and "HELLO" are equal
    }
    // </SnippetCollectionExpressionWithArguments>
}
