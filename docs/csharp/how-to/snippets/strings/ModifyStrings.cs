namespace HowToStrings;

public static class ModifyStrings
{
    public static void Examples()
    {
        ReplaceCreatesNewString();
        ReplaceChars();
        TrimWhitespace();
        RemoveText();
        ReplaceWithRegEx();
        ReplaceCharArray();
        UsingStringCreate();
    }

    private static void ReplaceCreatesNewString()
    {
        // <Snippet1>
        string source = "The mountains are behind the clouds today.";

        // Replace one substring with another with String.Replace.
        // Only exact matches are supported.
        var replacement = source.Replace("mountains", "peaks");
        Console.WriteLine($"The source string is <{source}>");
        Console.WriteLine($"The updated string is <{replacement}>");
        // </Snippet1>
    }

    private static void ReplaceChars()
    {
        // <Snippet2>
        string source = "The mountains are behind the clouds today.";

        // Replace all occurrences of one char with another.
        var replacement = source.Replace(' ', '_');
        Console.WriteLine(source);
        Console.WriteLine(replacement);
        // </Snippet2>
    }

    private static void TrimWhitespace()
    {
        // <Snippet3>
        // Remove trailing and leading white space.
        string source = "    I'm wider than I need to be.      ";
        // Store the results in a new string variable.
        var trimmedResult = source.Trim();
        var trimLeading = source.TrimStart();
        var trimTrailing = source.TrimEnd();
        Console.WriteLine($"<{source}>");
        Console.WriteLine($"<{trimmedResult}>");
        Console.WriteLine($"<{trimLeading}>");
        Console.WriteLine($"<{trimTrailing}>");
        // </Snippet3>
    }

    private static void RemoveText()
    {
        // <Snippet4>
        string source = "Many mountains are behind many clouds today.";
        // Remove a substring from the middle of the string.
        string toRemove = "many ";
        string result = string.Empty;
        int i = source.IndexOf(toRemove);
        if (i >= 0)
        {
            result= source.Remove(i, toRemove.Length);
        }
        Console.WriteLine(source);
        Console.WriteLine(result);
        // </Snippet4>
    }

    private static void ReplaceWithRegEx()
    {
        // <Snippet5>
        string source = "The mountains are still there behind the clouds today.";

        // Use Regex.Replace for more flexibility.
        // Replace "the" or "The" with "many" or "Many".
        // using System.Text.RegularExpressions
        string replaceWith = "many ";
        source = System.Text.RegularExpressions.Regex.Replace(source, """the\s""", LocalReplaceMatchCase,
            System.Text.RegularExpressions.RegexOptions.IgnoreCase);
        Console.WriteLine(source);

        string LocalReplaceMatchCase(System.Text.RegularExpressions.Match matchExpression)
        {
            // Test whether the match is capitalized
            if (Char.IsUpper(matchExpression.Value[0]))
            {
                // Capitalize the replacement string
                System.Text.StringBuilder replacementBuilder = new System.Text.StringBuilder(replaceWith);
                replacementBuilder[0] = Char.ToUpper(replacementBuilder[0]);
                return replacementBuilder.ToString();
            }
            else
            {
                return replaceWith;
            }
        }
        // </Snippet5>
    }

    private static void ReplaceCharArray()
    {
        // <Snippet6>
        string phrase = "The quick brown fox jumps over the fence";
        Console.WriteLine(phrase);

        char[] phraseAsChars = phrase.ToCharArray();
        int animalIndex = phrase.IndexOf("fox");
        if (animalIndex != -1)
        {
            phraseAsChars[animalIndex++] = 'c';
            phraseAsChars[animalIndex++] = 'a';
            phraseAsChars[animalIndex] = 't';
        }

        string updatedPhrase = new string(phraseAsChars);
        Console.WriteLine(updatedPhrase);
        // </Snippet6>
    }

    private static void UsingStringCreate()
    {
        // <Snippet7>
        // constructing a string from a char array, prefix it with some additional characters
        char[] chars = [ 'a', 'b', 'c', 'd', '\0' ];
        int length = chars.Length + 2;
        string result = string.Create(length, chars, (Span<char> strContent, char[] charArray) =>
        {
	            strContent[0] = '0';
	            strContent[1] = '1';
	            for (int i = 0; i < charArray.Length; i++)
	            {
		            strContent[i + 2] = charArray[i];
	            }
        });

        Console.WriteLine(result);
        // </Snippet7>
    }
}
