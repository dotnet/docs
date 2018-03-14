// <Snippet2>
using System;

public class Example
{
   public static void Main()
   {
      Console.OutputEncoding = System.Text.Encoding.UTF8;
      string word = "File";
      string[] others = { word.ToLower(), word, word.ToUpper(), "fıle" };
      foreach (string other in others)
      {
         if (word.Equals(other)) 
            Console.WriteLine("{0} = {1}", word, other);
         else
            Console.WriteLine("{0} {1} {2}", word, '\u2260', other);
      }        
   }
}
// The example displays the following output:
//       File ≠ file
//       File = File
//       File ≠ FILE
//       File ≠ fıle
// </Snippet2>

