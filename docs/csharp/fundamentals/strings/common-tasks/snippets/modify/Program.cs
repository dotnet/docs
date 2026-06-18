using System.Text.RegularExpressions;

namespace ModifyStrings;

public static class Program
{
    public static void Main()
    {
        ReplaceText();
        Console.WriteLine();
        ReplaceCharacters();
        Console.WriteLine();
        TrimWhitespace();
        Console.WriteLine();
        RemoveText();
        Console.WriteLine();
        ReplaceWithRegex();
        Console.WriteLine();
        ModifyCharacters();
    }

    private static void ReplaceText()
    {
        // <Replace>
        string source = "The mountains are behind the clouds today.";

        // Replace returns a new string; the original is unchanged.
        string updated = source.Replace("mountains", "peaks");

        Console.WriteLine(source);
        // => The mountains are behind the clouds today.
        Console.WriteLine(updated);
        // => The peaks are behind the clouds today.
        // </Replace>
    }

    private static void ReplaceCharacters()
    {
        // <ReplaceChar>
        string source = "The mountains are behind the clouds today.";

        // Replace every occurrence of one character with another.
        string updated = source.Replace(' ', '_');

        Console.WriteLine(updated);
        // => The_mountains_are_behind_the_clouds_today.
        // </ReplaceChar>
    }

    private static void TrimWhitespace()
    {
        // <Trim>
        string source = "    I'm wider than I need to be.      ";

        // Each method returns a new string with whitespace removed.
        Console.WriteLine($"<{source.Trim()}>");
        // => <I'm wider than I need to be.>
        Console.WriteLine($"<{source.TrimStart()}>");
        // => <I'm wider than I need to be.      >
        Console.WriteLine($"<{source.TrimEnd()}>");
        // => <    I'm wider than I need to be.>
        // </Trim>
    }

    private static void RemoveText()
    {
        // <Remove>
        string source = "Many mountains are behind many clouds today.";
        string toRemove = "many ";

        // Find the text, then remove that span by index and length.
        int index = source.IndexOf(toRemove);
        string result = index >= 0
            ? source.Remove(index, toRemove.Length)
            : source;

        Console.WriteLine(result);
        // => Many mountains are behind clouds today.
        // </Remove>
    }

    private static void ReplaceWithRegex()
    {
        // <Regex>
        string source = "The mountains are still there behind the clouds today.";

        // Replace "the" or "The" followed by whitespace, preserving the original case.
        // The \s in the pattern keeps "there" from matching.
        string result = Regex.Replace(
            source,
            """the\s""",
            match => char.IsUpper(match.Value[0]) ? "Many " : "many ",
            RegexOptions.IgnoreCase);

        Console.WriteLine(result);
        // => Many mountains are still there behind many clouds today.
        // </Regex>
    }

    private static void ModifyCharacters()
    {
        // <CharArray>
        string phrase = "The quick brown fox jumps over the fence.";

        // A string is immutable, so copy it to a char array to edit in place.
        char[] characters = phrase.ToCharArray();
        int index = phrase.IndexOf("fox");
        if (index != -1)
        {
            characters[index] = 'c';
            characters[index + 1] = 'a';
            characters[index + 2] = 't';
        }

        // Build a new string from the modified characters.
        string updated = new string(characters);
        Console.WriteLine(updated);
        // => The quick brown cat jumps over the fence.
        // </CharArray>
    }
}
