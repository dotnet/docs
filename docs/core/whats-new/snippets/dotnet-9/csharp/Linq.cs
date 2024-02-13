using System;
using System.Collections.Generic;
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
    }
}
