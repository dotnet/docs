using System.Collections.Generic;
using System.Globalization;
using System.Resources;

// <Snippet3>
using System;

public class Example
{
   public static void Main()
   {
      Double dbl = 0.0 - Double.Epsilon;
      Console.WriteLine(NumericLib.NearZero(dbl));
      
      string s = "war and peace";
      Console.WriteLine(s.ToTitleCase());
   }
}
// The example displays the following output:
//       True
//       War and Peace
// </Snippet3>

public static class NumericLib 
{
   public static bool IsEven(this IConvertible number)
   {
      if (number is Byte ||
          number is SByte ||
          number is Int16 ||
          number is UInt16 || 
          number is Int32 || 
          number is UInt32 ||
          number is Int64)
         return ((long) number) % 2 == 0;
      else if (number is UInt64)
         return ((ulong) number) %2 == 0;
      else
         throw new NotSupportedException("IsEven called for a non-integer value.");
   }
   
   public static bool NearZero(double number)
   {
      return number < .00001; 
   }
}

public static class StringLib
{
   private static List<string> exclusions; 
   
   static StringLib()
   {
      string[] words = { "a", "an", "and", "of", "the" };
      exclusions = new List<string>();
      exclusions.AddRange(words);
   }
   
   public static string ToTitleCase(this string title)
   {
      string[] words = title.Split(); 
      string result = String.Empty;
      
      for (int ctr = 0; ctr < words.Length; ctr++) {
         string word = words[ctr];
         if (ctr == 0 || !(exclusions.Contains(word.ToLower())))
            result += word.Substring(0, 1).ToUpper() + 
                      word.Substring(1).ToLower();
         else
            result += word.ToLower();

         if (ctr <= words.Length - 1)
            result += " ";             
      } 
      return result; 
   }
}