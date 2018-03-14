using System;
using System.Globalization;
using System.Threading;

public class Example
{
   public static void Main()
   {
      // <Snippet13>
      CultureInfo.CurrentCulture = CultureInfo.CreateSpecificCulture(Request.UserLanguages[0]);
      // </Snippet13>
   }
}

public class Request
{
   private static string[] langs = new string[3];
   
   public static string[] UserLanguages { get { return langs; } }
}