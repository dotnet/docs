namespace SplitStrings;

public static class Program
{
    public static void Main()
    {
        SplitWords();
        Console.WriteLine();
        IndexWords();
        Console.WriteLine();
        RepeatedSeparators();
        Console.WriteLine();
        MultiChar();
        Console.WriteLine();
        MultiCharGaps();
        Console.WriteLine();
        StringSeparators();
        Console.WriteLine();
        LimitCount();
        Console.WriteLine();
        TrimEntries();
    }

    private static void SplitWords()
    {
        // <SplitWords>
        string phrase = "The quick brown fox jumps over the lazy dog.";
        string[] words = phrase.Split(' ');

        foreach (var word in words)
        {
            Console.WriteLine($"<{word}>");
        }
        // => <The>
        // => <quick>
        // => <brown>
        // => <fox>
        // => <jumps>
        // => <over>
        // => <the>
        // => <lazy>
        // => <dog.>
        // </SplitWords>
    }

    private static void IndexWords()
    {
        // <IndexWords>
        string phrase = "The quick brown fox jumps over the lazy dog.";
        string[] words = phrase.Split(' ');

        for (int i = 0; i < words.Length; i++)
        {
            Console.WriteLine($"Index {i}: <{words[i]}>");
        }
        // => Index 0: <The>
        // => Index 1: <quick>
        // => Index 2: <brown>
        // => ...
        // </IndexWords>
    }

    private static void RepeatedSeparators()
    {
        // <RepeatedSeparators>
        string phrase = "The quick brown    fox     jumps over the lazy dog.";
        string[] words = phrase.Split(' ');

        foreach (var word in words)
        {
            Console.WriteLine($"<{word}>");
        }
        // The runs of spaces produce empty entries:
        // => <The>
        // => <quick>
        // => <brown>
        // => <>
        // => <>
        // => <>
        // => <fox>
        // => ...
        // </RepeatedSeparators>
    }

    private static void MultiChar()
    {
        // <MultiChar>
        char[] delimiters = [' ', ',', '.', ':', '\t'];

        string text = "one\ttwo three:four,five six seven";
        Console.WriteLine($"Original text: '{text}'");

        string[] words = text.Split(delimiters);
        Console.WriteLine($"{words.Length} words in text:");

        foreach (var word in words)
        {
            Console.WriteLine($"<{word}>");
        }
        // => 7 words in text:
        // => <one>
        // => <two>
        // => <three>
        // => <four>
        // => <five>
        // => <six>
        // => <seven>
        // </MultiChar>
    }

    private static void MultiCharGaps()
    {
        // <MultiCharGaps>
        char[] delimiters = [' ', ',', '.', ':', '\t'];

        string text = "one\ttwo :,five six seven";
        Console.WriteLine($"Original text: '{text}'");

        string[] words = text.Split(delimiters);
        Console.WriteLine($"{words.Length} words in text:");

        foreach (var word in words)
        {
            Console.WriteLine($"<{word}>");
        }
        // Adjacent delimiters produce empty entries — use StringSplitOptions.RemoveEmptyEntries to drop them.
        // </MultiCharGaps>
    }

    private static void StringSeparators()
    {
        // <StringSeparators>
        string[] separators = ["<<", "..."];

        string text = "one<<two......three<four";
        Console.WriteLine($"Original text: '{text}'");

        string[] words = text.Split(separators, StringSplitOptions.RemoveEmptyEntries);
        Console.WriteLine($"{words.Length} substrings in text:");

        foreach (var word in words)
        {
            Console.WriteLine(word);
        }
        // => 3 substrings in text:
        // => one
        // => two
        // => three<four
        // </StringSeparators>
    }

    private static void LimitCount()
    {
        // <LimitCount>
        string phrase = "The quick brown fox jumps over the lazy dog.";
        string[] words = phrase.Split(' ', 4, StringSplitOptions.None);

        foreach (var word in words)
        {
            Console.WriteLine($"<{word}>");
        }
        // => <The>
        // => <quick>
        // => <brown>
        // => <fox jumps over the lazy dog.>
        // </LimitCount>
    }

    private static void TrimEntries()
    {
        // <TrimEntries>
        string numerals = "1, 2, 3, 4, 5, 6, 7, 8, 9, 10";
        string[] trimmed = numerals.Split(',', StringSplitOptions.TrimEntries);

        Console.WriteLine("Trimmed entries:");
        foreach (var word in trimmed)
        {
            Console.WriteLine($"<{word}>");
        }

        string[] untrimmed = numerals.Split(',', StringSplitOptions.None);
        Console.WriteLine("Untrimmed entries:");
        foreach (var word in untrimmed)
        {
            Console.WriteLine($"<{word}>");
        }
        // => Trimmed entries: <1> <2> ... <10>
        // => Untrimmed entries: <1> < 2> ... < 10>
        // </TrimEntries>
    }
}
