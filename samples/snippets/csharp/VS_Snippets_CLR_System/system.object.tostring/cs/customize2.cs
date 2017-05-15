// <Snippet8>
using System;
using System.Collections.Generic;

public static class StringExtensions
{
   public static String ToString2<T>(this List<T> l)
   {
      String retVal = String.Empty;
      foreach (T item in l)
         retVal += String.Format("{0}{1}", String.IsNullOrEmpty(retVal) ?
                                                     "" : ", ",
                                  item);
      return String.IsNullOrEmpty(retVal) ? "{}" : "{ " + retVal + " }";
   }

   public static String ToString<T>(this List<T> l, String fmt)
   {
      String retVal = String.Empty;
      foreach (T item in l) {
         IFormattable ifmt = item as IFormattable;
         if (ifmt != null)
            retVal += String.Format("{0}{1}",
                                    String.IsNullOrEmpty(retVal) ?
                                       "" : ", ", ifmt.ToString(fmt, null));
         else
            retVal += ToString2(l);
      }
      return String.IsNullOrEmpty(retVal) ? "{}" : "{ " + retVal + " }";
   }
}

public class Example
{
   public static void Main()
   {
      List<int> list = new List<int>();
      list.Add(1000);
      list.Add(2000);
      Console.WriteLine(list.ToString2());
      Console.WriteLine(list.ToString("N0"));
   }
}
// The example displays the following output:
//       { 1000, 2000 }
//       { 1,000, 2,000 }
// </Snippet8>

