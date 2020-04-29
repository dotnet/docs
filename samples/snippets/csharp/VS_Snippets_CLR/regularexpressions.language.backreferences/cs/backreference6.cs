using System;
using System.Text.RegularExpressions;

public class Example
{
   public static void Main()
   {
      Console.WriteLine(Regex.IsMatch("aa", @"(?<char>\w)\k<1>"));
      // Displays "True".
   }
}
