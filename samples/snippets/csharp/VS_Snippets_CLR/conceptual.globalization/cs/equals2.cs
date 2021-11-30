// <Snippet13>
using System;
using System.Globalization;
using System.Threading;

public class Example11
{
   public static void Main11()
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
      return uri.StartsWith("FILE", StringComparison.OrdinalIgnoreCase);
   }
}
// The example displays the following output:
//         Access is not allowed.
// </Snippet13>
