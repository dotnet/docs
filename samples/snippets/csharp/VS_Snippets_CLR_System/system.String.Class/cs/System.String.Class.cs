// <Snippet1>
using System;
using System.Text;

public class StringClassTest
{
   public static void Main()
   {
      string characters = "abc\u0000def";
      Console.WriteLine(characters.Length);    // Displays 7
   }
}
// </Snippet1>      
