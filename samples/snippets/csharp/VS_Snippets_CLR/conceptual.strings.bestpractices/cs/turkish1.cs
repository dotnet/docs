// <Snippet11>
using System;
using System.Globalization;
using System.Threading;

public class Example
{
   public static void Main()
   {
      string fileUrl = "file";
      Thread.CurrentThread.CurrentCulture = new CultureInfo("en-US");
      Console.WriteLine("Culture = {0}",
                        Thread.CurrentThread.CurrentCulture.DisplayName);
      Console.WriteLine("(file == FILE) = {0}",
                       fileUrl.StartsWith("FILE", true, null));
      Console.WriteLine();

      Thread.CurrentThread.CurrentCulture = new CultureInfo("tr-TR");
      Console.WriteLine("Culture = {0}",
                        Thread.CurrentThread.CurrentCulture.DisplayName);
      Console.WriteLine("(file == FILE) = {0}",
                        fileUrl.StartsWith("FILE", true, null));
   }
}
// The example displays the following output:
//       Culture = English (United States)
//       (file == FILE) = True
//
//       Culture = Turkish (Turkey)
//       (file == FILE) = False
// </Snippet11>

public class Example2
{
   // <Snippet12>
   public static bool IsFileURI(String path)
   {
      return path.StartsWith("FILE:", true, null);
   }
   // </Snippet12>
}

public class Example3
{
   // <Snippet13>
   public static bool IsFileURI(string path)
   {
      return path.StartsWith("FILE:", StringComparison.OrdinalIgnoreCase);
   }
   // </Snippet13>
}

public class Example4
{
   // <Snippet14>
   public static bool IsFileURI(string path)
   {
      if (path.Length < 5) return false;

      return String.Equals(path.Substring(0, 5), "FILE:",
                           StringComparison.OrdinalIgnoreCase);
   }
   // </Snippet14>
}
