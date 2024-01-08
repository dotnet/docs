// <Snippet4>
using System;
using System.Text;

public class Example
{
   public static void Main()
   {
      StringBuilder sb = new StringBuilder();
      sb.Append("This is the beginning of a sentence, ");
      sb.Replace("the beginning of ", "");
      sb.Insert(sb.ToString().IndexOf("a ") + 2, "complete ");
      sb.Replace(",", ".");
      Console.WriteLine(sb.ToString());
   }
}
// The example displays the following output:
//        This is a complete sentence.
// </Snippet4>
