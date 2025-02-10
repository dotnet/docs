namespace HowToStrings;

public static class ParseStringsUsingSplit
{
    public static void Examples()
    {
        Console.WriteLine("Split words");
        Console.WriteLine();
        SplitWords();

        Console.WriteLine("Enumerate words");
        Console.WriteLine();
        EnumerateWords();

        Console.WriteLine("Split words with repeated separators");
        Console.WriteLine();
        SplitWordsWithRepeatedSeparators();

        Console.WriteLine("Split on multiple chars");
        Console.WriteLine();
        SplitOnMultipleChars();

        Console.WriteLine("Split on multiple chars with gaps");
        Console.WriteLine();
        SplitOnMultipleCharsWithGaps();

        Console.WriteLine("Split using strings");
        Console.WriteLine();
        SplitUsingStrings();

        Console.WriteLine("Split into no more than four substrings");
        Console.WriteLine();
        SplitFourTimes();
    }

    private static void SplitWords()
    {
        // <Snippet1>
        string phrase = "The quick brown fox jumps over the lazy dog.";
        string[] words = phrase.Split(' ');

        foreach (var word in words)
        {
            Console.WriteLine($"<{word}>");
        }
        // </Snippet1>
    }

    private static void EnumerateWords()
    {
        // <Snippet1.5>
        string phrase = "The quick brown fox jumps over the lazy dog.";
        string[] words = phrase.Split(' ');

        for (int i = 0; i < words.Length; i++)
        {
            Console.WriteLine($"Index {i}: <{words[i]}>");
        }
        // </Snippet1.5>
    }

    private static void SplitWordsWithRepeatedSeparators()
    {
        // <Snippet2>
        string phrase = "The quick brown    fox     jumps over the lazy dog.";
        string[] words = phrase.Split(' ');

        foreach (var word in words)
        {
            Console.WriteLine($"<{word}>");
        }
        // </Snippet2>
    }

    private static void SplitOnMultipleChars()
    {
        // <Snippet3>
        char[] delimiterChars = [' ', ',', '.', ':', '\t'];

        string text = "one\ttwo three:four,five six seven";
        Console.WriteLine($"Original text: '{text}'");

        string[] words = text.Split(delimiterChars);
        Console.WriteLine($"{words.Length} words in text:");

        foreach (var word in words)
        {
            Console.WriteLine($"<{word}>");
        }
        // </Snippet3>
    }

    private static void SplitOnMultipleCharsWithGaps()
    {
        // <Snippet4>
        char[] delimiterChars = [' ', ',', '.', ':', '\t'];

        string text = "one\ttwo :,five six seven";
        Console.WriteLine($"Original text: '{text}'");

        string[] words = text.Split(delimiterChars);
        Console.WriteLine($"{words.Length} words in text:");

        foreach (var word in words)
        {
            Console.WriteLine($"<{word}>");
        }
        // </Snippet4>
    }

    private static void SplitUsingStrings()
    {
        // <Snippet5>
        string[] separatingStrings = ["<<", "..."];

        string text = "one<<two......three<four";
        Console.WriteLine($"Original text: '{text}'");

        string[] words = text.Split(separatingStrings, StringSplitOptions.RemoveEmptyEntries);
        Console.WriteLine($"{words.Length} substrings in text:");

        foreach (var word in words)
        {
            Console.WriteLine(word);
        }
        // </Snippet5>
    }

    private static void SplitFourTimes()
    {
        // <Snippet6>
        string phrase = "The quick brown fox jumps over the lazy dog.";
        string[] words = phrase.Split(' ', 4, StringSplitOptions.None);

        foreach (var word in words)
        {
            Console.WriteLine($"<{word}>");
        }
        // </Snippet6>
    }
}
