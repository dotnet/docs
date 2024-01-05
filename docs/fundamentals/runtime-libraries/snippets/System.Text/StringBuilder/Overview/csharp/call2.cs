// <Snippet5>
using System;
using System.Text;

public class Example2
{
    public static void Main()
    {
        StringBuilder sb = new StringBuilder("This is the beginning of a sentence, ");
        sb.Replace("the beginning of ", "").Insert(sb.ToString().IndexOf("a ") + 2,
                                                   "complete ").Replace(",", ".");
        Console.WriteLine(sb.ToString());
    }
}
// The example displays the following output:
//        This is a complete sentence.
// </Snippet5>
