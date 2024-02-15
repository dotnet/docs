using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

static class Linq
{
    public static void RunIt()
    {
        // <CountBy>
        string sourceText = """
            Lorem ipsum dolor sit amet, consectetur adipiscing elit.
            Sed non risus. Suspendisse lectus tortor, dignissim sit amet, 
            adipiscing nec, ultricies sed, dolor. Cras elementum ultrices amet diam.
        """;

        // Find the most frequent word in the text.
        KeyValuePair<string, int> mostFrequentWord = sourceText
            .Split(new char[] { ' ', '.', ',' }, StringSplitOptions.RemoveEmptyEntries)
            .Select(word => word.ToLowerInvariant())
            .CountBy(word => word)
            .MaxBy(pair => pair.Value);

        Console.WriteLine(mostFrequentWord.Key); // amet
        // </CountBy>

        // <AggregateBy>
        (string id, int score)[] data =
            [
                ("0", 42),
                ("1", 5),
                ("2", 4),
                ("1", 10),
                ("0", 25),
            ];

        var aggregatedData =
            data.AggregateBy(
                keySelector: entry => entry.id,
                seed: 0,
                (totalScore, curr) => totalScore + curr.score
                );

        foreach (var item in aggregatedData)
        {
            Console.WriteLine(item);
        }
        //(0, 67)
        //(1, 15)
        //(2, 4)
        // </AggregateBy>

        // <OldIndex>
        IEnumerable<string> lines1 = File.ReadAllLines("output.txt");
        foreach ((int index, string line) in lines1.Select((line, index) => (index, line)))
        {
            Console.WriteLine($"Line number: {index + 1}, Line: {line}");
        }
        // </OldIndex>

        // <NewIndex>
        IEnumerable<string> lines2 = File.ReadAllLines("output.txt");
        foreach ((int index, string line) in lines2.Index())
        {
            Console.WriteLine($"Line number: {index + 1}, Line: {line}");
        }
        // </NewIndex>
    }
}
