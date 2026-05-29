using System.Text;
using System.Text.RegularExpressions;

namespace ModifyStrings;

public static class Program
{
    public static void Main()
    {
        Replace();
        Console.WriteLine();
        Trim();
        Console.WriteLine();
        Remove();
        Console.WriteLine();
        RegexReplace();
    }

    private static void Replace()
    {
        // <Replace>
        string source = "The mountains are behind the clouds today.";

        string updated = source.Replace("mountains", "peaks");
        Console.WriteLine(source);
        Console.WriteLine(updated);
        // => The mountains are behind the clouds today.
        // => The peaks are behind the clouds today.

        // Replace every occurrence of a single character.
        string spaced = source.Replace(' ', '_');
        Console.WriteLine(spaced);
        // => The_mountains_are_behind_the_clouds_today.
        // </Replace>
    }

    private static void Trim()
    {
        // <Trim>
        string padded = "    I'm wider than I need to be.      ";

        Console.WriteLine($"<{padded.Trim()}>");
        Console.WriteLine($"<{padded.TrimStart()}>");
        Console.WriteLine($"<{padded.TrimEnd()}>");
        // => <I'm wider than I need to be.>
        // => <I'm wider than I need to be.      >
        // => <    I'm wider than I need to be.>
        // </Trim>
    }

    private static void Remove()
    {
        // <Remove>
        string source = "Many mountains are behind many clouds today.";

        string toRemove = "many ";
        int index = source.IndexOf(toRemove);
        string result = index >= 0 ? source.Remove(index, toRemove.Length) : source;

        Console.WriteLine(source);
        Console.WriteLine(result);
        // => Many mountains are behind many clouds today.
        // => Many mountains are behind clouds today.
        // </Remove>
    }

    private static void RegexReplace()
    {
        // <Regex>
        string source = "The mountains are still there behind the clouds today.";
        string replacement = "many ";

        string updated = Regex.Replace(
            source,
            @"the\s",
            match =>
            {
                if (char.IsUpper(match.Value[0]))
                {
                    var builder = new StringBuilder(replacement);
                    builder[0] = char.ToUpper(builder[0]);
                    return builder.ToString();
                }

                return replacement;
            },
            RegexOptions.IgnoreCase);

        Console.WriteLine(source);
        Console.WriteLine(updated);
        // => The mountains are still there behind the clouds today.
        // => Many mountains are still there behind many clouds today.
        // </Regex>
    }
}
