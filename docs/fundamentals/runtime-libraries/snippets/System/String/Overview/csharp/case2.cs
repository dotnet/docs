// <Snippet17>
using System;
using System.Globalization;
using System.Threading;

public class Example1
{
   const string disallowed = "file";
   
   public static void Main()
   {
      IsAccessAllowed(@"FILE:\\\c:\users\user001\documents\FinancialInfo.txt");
   }

   private static void IsAccessAllowed(String resource)
   {
      CultureInfo[] cultures = { CultureInfo.CreateSpecificCulture("en-US"),
                                 CultureInfo.CreateSpecificCulture("tr-TR") };
      String scheme = null;
      int index = resource.IndexOfAny( new Char[] { '\\', '/' } );
      if (index > 0) 
         scheme = resource.Substring(0, index - 1);

      // Change the current culture and perform the comparison.
      foreach (var culture in cultures) {
         Thread.CurrentThread.CurrentCulture = culture;
         Console.WriteLine($"Culture: {CultureInfo.CurrentCulture.DisplayName}");
         Console.WriteLine(resource);
         Console.WriteLine("Access allowed: {0}", 
                           ! String.Equals(disallowed, scheme, StringComparison.CurrentCultureIgnoreCase));      
         Console.WriteLine();
      }   
   }
}
// The example displays the following output:
//       Culture: English (United States)
//       FILE:\\\c:\users\user001\documents\FinancialInfo.txt
//       Access allowed: False
//       
//       Culture: Turkish (Turkey)
//       FILE:\\\c:\users\user001\documents\FinancialInfo.txt
//       Access allowed: True
// </Snippet17>
