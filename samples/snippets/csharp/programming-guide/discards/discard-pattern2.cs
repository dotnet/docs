using System;
using System.Globalization;

public class Example
{
   public static void Main()
   {
      object[] objects = { CultureInfo.CurrentCulture, 
                           CultureInfo.CurrentCulture.DateTimeFormat, 
                           CultureInfo.CurrentCulture.NumberFormat,
                           new ArgumentException(), null };
      foreach (var obj in objects)
         ProvidesFormatInfo(obj);
   }

   private static void ProvidesFormatInfo(object obj)         
   {
      if (obj is IFormatProvider fmt)
         Console.WriteLine($"{fmt} object");
      else if (obj is null) {
         Console.Write("A null object reference: ");
         Console.WriteLine("Its use could result in a NullReferenceException");
      }
      else if (obj is var _)
         Console.WriteLine($"Some object type without format information");
   }
}
// The example displays the following output:
//    en-US object
//    System.Globalization.DateTimeFormatInfo object
//    System.Globalization.NumberFormatInfo object
//    Some object type without format information
//    A null object reference: Its use could result in a NullReferenceException

