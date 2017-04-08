using System;
using System.Globalization;
using System.Threading;

public class Example
{
   public static void Main()
   {
      // <Snippet3>
      Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture(Request.UserLanguages[0]);
      // </Snippet3>
   }
}

public class Request
{
   private static string[] langs = new string[3];
   
   public static string[] UserLanguages { get { return langs; } }
}