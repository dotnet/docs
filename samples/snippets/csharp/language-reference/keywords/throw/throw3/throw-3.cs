// <Snippet3>
using System;

namespace Throw
{
public class Sentence
{
   public Sentence(string s)
   {
      Value = s;
   }

   public string Value { get; set; }

   public char GetFirstCharacter()
   {
      try
      {
         return Value[0];
      }
      catch (NullReferenceException e)
      {
         throw;
      }
   }
}

public class Example
{
   public static void Main()
   {
      var s = new Sentence(null);
      Console.WriteLine($"The first character is {s.GetFirstCharacter()}");
   }
}
// The example displays the following output:
//    Unhandled Exception: System.NullReferenceException: Object reference not set to an instance of an object.
//       at Sentence.GetFirstCharacter()
//       at Example.Main()
// </Snippet3>
}