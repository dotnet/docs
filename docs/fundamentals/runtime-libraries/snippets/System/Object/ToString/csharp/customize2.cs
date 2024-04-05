// <Snippet8>
using System;
using System.Collections.Generic;

public static class StringExtensions
{
   public static string ToString2<T>(this List<T> l)
   {
      string retVal = string.Empty;
      foreach (T item in l)
         retVal += string.Format("{0}{1}", string.IsNullOrEmpty(retVal) ?
                                                     "" : ", ",
                                  item);
      return string.IsNullOrEmpty(retVal) ? "{}" : "{ " + retVal + " }";
   }

   public static string ToString<T>(this List<T> l, string fmt)
   {
      string retVal = string.Empty;
      foreach (T item in l) {
         IFormattable ifmt = item as IFormattable;
         if (ifmt != null)
            retVal += string.Format("{0}{1}",
                                    string.IsNullOrEmpty(retVal) ?
                                       "" : ", ", ifmt.ToString(fmt, null));
         else
            retVal += ToString2(l);
      }
      return string.IsNullOrEmpty(retVal) ? "{}" : "{ " + retVal + " }";
   }
}

public class Example3
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
