using System;
using System.Text;

public class StringClassTest
{
   public static void Main()
   {
      // <Snippet1>
      string characters = "abc\u0000def";
      Console.WriteLine(characters.Length); // Displays 7
      // </Snippet1>      
   }
}
