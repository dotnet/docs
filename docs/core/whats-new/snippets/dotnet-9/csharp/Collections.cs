using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text.RegularExpressions;

internal static class Collections
{
    // <UpdatePriority>
    public static void UpdatePriority<TElement, TPriority>(
        this PriorityQueue<TElement, TPriority> queue,
        TElement element,
        TPriority priority
        )
    {
        // Scan the heap for entries matching the current element.
        queue.Remove(element, out _, out _);
        // Re-insert the entry with the new priority.
        queue.Enqueue(element, priority);
    }
    // </UpdatePriority>

    public static void RunIt()
    {
        // <OrderedDictionary>
        OrderedDictionary<string, int> d = new()
        {
            ["a"] = 1,
            ["b"] = 2,
            ["c"] = 3,
        };

        d.Add("d", 4);
        d.RemoveAt(0);
        d.RemoveAt(2);
        d.Insert(0, "e", 5);

        foreach (KeyValuePair<string, int> entry in d)
        {
            Console.WriteLine(entry);
        }

        // Output:
        // [e, 5]
        // [b, 2]
        // [c, 3]

        // </OrderedDictionary>
    }
}

internal partial class ReadOnlyCollections
{
    // <ReadOnlySet>
    private readonly HashSet<int> _set = [];
    private ReadOnlySet<int>? _setWrapper;

    public ReadOnlySet<int> Set => _setWrapper ??= new(_set);
    // </ReadOnlySet>

    // <AlternateLookup>
    static Dictionary<string, int> CountWords(ReadOnlySpan<char> input)
    {
        Dictionary<string, int> wordCounts = new(StringComparer.OrdinalIgnoreCase);
        Dictionary<string, int>.AlternateLookup<ReadOnlySpan<char>> spanLookup =
            wordCounts.GetAlternateLookup<ReadOnlySpan<char>>();

        foreach (Range wordRange in Regex.EnumerateSplits(input, @"\b\W+"))
        {
            if (wordRange.Start.Value == wordRange.End.Value)
            {
                continue; // Skip empty ranges.
            }
            ReadOnlySpan<char> word = input[wordRange];
            spanLookup[word] = spanLookup.TryGetValue(word, out int count) ? count + 1 : 1;
        }

        return wordCounts;
    }
    // </AlternateLookup>
}
