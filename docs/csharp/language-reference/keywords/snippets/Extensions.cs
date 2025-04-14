namespace keywords;

// <ExtensionMembers>
public static class NumericSequences
{
    extension(IEnumerable<int> sequence)
    {
        public IEnumerable<int> Add(int operand)
        {
            foreach (var item in sequence)
            {
                yield return item + operand;
            }
        }

        public int Median
        {
            get
            {

                var sortedList = sequence.OrderBy(n => n).ToList();
                int count = sortedList.Count;
                int middleIndex = count / 2;

                if (count % 2 == 0)
                {
                    // Even number of elements: average the two middle elements
                    return (sortedList[middleIndex - 1] + sortedList[middleIndex]);
                }
                else
                {
                    // Odd number of elements: return the middle element
                    return sortedList[middleIndex];
                }
            }
        }

        public int this[int index] => sequence.Skip(index).First();
    }
}
// </ExtensionMembers>

public static class NumericStaticExtensions
{
    // <StaticExtensions>
    extension(IEnumerable<int>)
    {
        // Method:
        public static IEnumerable<int> Generate(int low, int count, int increment)
        {
            for (int i = 0; i < count; i++)
                yield return low + (i * increment);
        }

        // Property:
        public static IEnumerable<int> Identity => Enumerable.Empty<int>();
    }
    // </StaticExtensions>
}

public static class ExtensionExamples
{
    public static void BasicExample()
    {
        // <UseExtensionMethod>
        IEnumerable<int> numbers = Enumerable.Range(1, 10);
        numbers = numbers.Add(10);

        var median = numbers.Median;
        // </UseExtensionMethod>

        // <UseStaticExtensions>
        var newSequence = IEnumerable<int>.Generate(5, 10, 2);
        var identity = IEnumerable<int>.Identity;
        // </UseStaticExtensions>
    }
}
