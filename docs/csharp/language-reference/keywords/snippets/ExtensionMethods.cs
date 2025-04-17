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

// <GenericExtensionMethods>
public static class GenericExtensions
{
    public static IEnumerable<T> Spread<T>(this IEnumerable<T> source, int start, int count)
        => source.Skip(start).Take(count);

    public static IEnumerable<T1> Append<T1, T2>(this IEnumerable<T1> source, IEnumerable<T2> second, Func<T2, T1> Converter)
    {
        foreach (T1 item in source)
        {
            yield return item;
        }
        foreach (T2 item in second)
        {
            yield return Converter(item);
        }
    }

    public static IEnumerable<T1> Prepend<T1, T2>(this IEnumerable<T1> source, IEnumerable<T2> second, Func<T2, T1> Converter)
    {
        foreach (T2 item in second)
        {
            yield return Converter(item);
        }
        foreach (T1 item in source)
        {
            yield return item;
        }
    }
}
// </GenericExtensionMethods>


