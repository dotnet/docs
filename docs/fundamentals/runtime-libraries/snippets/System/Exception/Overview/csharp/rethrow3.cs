﻿using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

public static class Library
{
   public static int[] FindOccurrences(this String s, String f)
   {
      var indexes = new List<int>();
      int currentIndex = 0;
      try {
         while (currentIndex >= 0 && currentIndex < s.Length) {
            currentIndex = s.IndexOf(f, currentIndex);
            if (currentIndex >= 0) {
               indexes.Add(currentIndex);
               currentIndex++;
            }
         }
      }
      catch (ArgumentNullException e) {
         // Perform some action here, such as logging this exception.
// <Snippet8>
         throw new ArgumentNullException("You must supply a search string.",
                                         e);
// </Snippet8>
      }
      return indexes.ToArray();
   }
}

public class Example
{
   public static void Main()
   {
      String s = "It was a cold day when...";
      int[] indexes = s.FindOccurrences("a");
      ShowOccurrences(s, "a", indexes);
      Console.WriteLine();

      String toFind = null;
      // <Snippet9>
      try {
         indexes = s.FindOccurrences(toFind);
         ShowOccurrences(s, toFind, indexes);
      }
      catch (ArgumentNullException e) {
         Console.WriteLine("An exception ({0}) occurred.",
                           e.GetType().Name);
         Console.WriteLine("   Message:\n{0}", e.Message);
         Console.WriteLine("   Stack Trace:\n   {0}", e.StackTrace);
         Exception ie = e.InnerException;
         if (ie != null) {
            Console.WriteLine("   The Inner Exception:");
            Console.WriteLine("      Exception Name: {0}", ie.GetType().Name);
            Console.WriteLine("      Message: {0}\n", ie.Message);
            Console.WriteLine("      Stack Trace:\n   {0}\n", ie.StackTrace);
         }
      }
      // The example displays the following output:
      //    'a' occurs at the following character positions: 4, 7, 15
      //
      //    An exception (ArgumentNullException) occurred.
      //       Message: You must supply a search string.
      //
      //       Stack Trace:
      //          at Library.FindOccurrences(String s, String f)
      //       at Example.Main()
      //
      //       The Inner Exception:
      //          Exception Name: ArgumentNullException
      //          Message: Value cannot be null.
      //    Parameter name: value
      //
      //          Stack Trace:
      //          at System.String.IndexOf(String value, Int32 startIndex, Int32 count, Stri
      //    ngComparison comparisonType)
      //       at Library.FindOccurrences(String s, String f)
      // </Snippet9>
   }

   private static void ShowOccurrences(String s, String toFind, int[] indexes)
   {
      Console.Write("'{0}' occurs at the following character positions: ",
                    toFind);
      for (int ctr = 0; ctr < indexes.Length; ctr++)
         Console.Write("{0}{1}", indexes[ctr],
                       ctr == indexes.Length - 1 ? "" : ", ");

      Console.WriteLine();
   }
}
