// <Snippet2>
using System;

public class SplitTest {
    public static void Main() {

        string words = "This is a list of words, with: a bit of punctuation" +
                       "\tand a tab character.";

        string [] split = words.Split(new Char [] {' ', ',', '.', ':', '\t' });

        foreach (string s in split) {

            if (s.Trim() != "")
                Console.WriteLine(s);
        }
    }
}
// The example displays the following output to the console:
//       This
//       is
//       a
//       list
//       of
//       words
//       with
//       a
//       bit
//       of
//       punctuation
//       and
//       a
//       tab
//       character
// </Snippet2>

