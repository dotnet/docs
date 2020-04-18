using System;
using System.Text.RegularExpressions;

public class Example
{
   public static void Main()
   {
      Console.WriteLine(Regex.IsMatch("aa", @"(?<2>\w)\k<1>"));
      // Throws an ArgumentException.
   }
}
