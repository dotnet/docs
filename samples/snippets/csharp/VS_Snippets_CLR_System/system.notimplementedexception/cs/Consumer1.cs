// <Snippet4>
using System;
using Utilities;

class Example
{
   public static void Main()
   {
      string eol = "";
      if (StringLibrary.Version.Major >= 2)
         eol = StringLibrary.GetendOfLineCharacter();
      else
         eol = "\n";

      Console.Write("The first line." + eol);
      Console.Write("The second line." + eol);
   }
}
// </Snippet4>
