using System;
using System.Collections.Generic;

public class IndexOfExample
{
    public static void Example1()
    {
        // <Snippet1>
        String s = "This is the first sentence in a string. " +
                       "More sentences will follow. For example, " +
                       "this is the third sentence. This is the " +
                       "fourth. And this is the fifth and final " +
                       "sentence.";
        var sentences = new List<String>();
        int start = 0;
        int position;

        // Extract sentences from the string.
        do
        {
            position = s.IndexOf('.', start);
            if (position >= 0)
            {
                sentences.Add(s.Substring(start, position - start + 1).Trim());
                start = position + 1;
            }
        } while (position > 0);

        // Display the sentences.
        foreach (var sentence in sentences)
            Console.WriteLine(sentence);

        // The example displays the following output:
        //       This is the first sentence in a string.
        //       More sentences will follow.
        //       For example, this is the third sentence.
        //       This is the fourth.
        //       And this is the fifth and final sentence.
        // </Snippet1>
    }
}
