using System;
using System.Collections.Generic;
using System.Text;

namespace keywords_ExtensionMethods;

// <ExtensionMethod>
public static class NumericSequenceExtensionMethods
{
    public static IEnumerable<int> Add(this IEnumerable<int> sequence, int operand)
    {
        foreach (var item in sequence)
            yield return item + operand;
    }
}
// </ExtensionMethod>

public static class ExtensionExamples
{
    public static void BasicExample()
    {
        // <UseExtensionMethod>
        IEnumerable<int> numbers = Enumerable.Range(1, 10);
        numbers = numbers.Add(10);
        // </UseExtensionMethod>
    }
}

