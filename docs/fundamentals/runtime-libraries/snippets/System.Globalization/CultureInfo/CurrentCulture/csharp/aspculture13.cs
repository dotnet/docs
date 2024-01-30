using System;
using System.Globalization;
using System.Threading;

public class Example13
{
   public static void Main()
   {
      // <Snippet13>
      CultureInfo.CurrentCulture = CultureInfo.CreateSpecificCulture(Request13.UserLanguages[0]);
      // </Snippet13>
   }
}

public class Request13
{
   private static string[] langs = new string[3];

   public static string[] UserLanguages { get { return langs; } }
}
