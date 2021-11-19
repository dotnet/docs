// <Snippet12>
using System;
using System.Globalization;
using System.Threading;

public class Example10
{
   public static void Main10()
   {
      Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture("tr-TR");
      string uri = @"file:\\c:\users\username\Documents\bio.txt";
      if (! AccessesFileSystem(uri))
         // Permit access to resource specified by URI
         Console.WriteLine("Access is allowed.");
      else
         // Prohibit access.
         Console.WriteLine("Access is not allowed.");
   }

   private static bool AccessesFileSystem(string uri)
   {
      return uri.StartsWith("FILE", true, CultureInfo.CurrentCulture);
   }
}
// The example displays the following output:
//         Access is allowed.
// </Snippet12>
