namespace TourOfCsharp
{
    public class CollectionExpressions
    {
        public static void Examples()
        {
            // <CollectionExpressions>
            int[] numbers = [1, 2, 3, 4, 5, 6, 7, 8, 9, 10];
            List<string> names = ["Alice", "Bob", "Charlie", "David"];

            IEnumerable<int> moreNumbers = [.. numbers, 11, 12, 13];
            IEnumerable<string> empty = [];
            // </CollectionExpressions>

            // <RangeAndIndex>
            string second = names[1]; // 0-based index
            string last = names[^1]; // ^1 is the last element
            int[] smallNumbers = numbers[0..5]; // 0 to 4
            // </RangeAndIndex>
        }
    }
}
