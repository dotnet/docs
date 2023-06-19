using System;
using System.IO;

// <Snippet5>
public enum Color { Red = 1, Blue = 2, Green = 3 };
// </Snippet5>

public class Class1
{
   public static void Main()
   {
      ShowGSpecifier();
      ShowFSpecifier();
      ShowDSpecifier();
      ShowXSpecifier();
      ShowExample();
   }

   private static void ShowGSpecifier()
   {
      Console.WriteLine("G Specifier:");
      // <Snippet1>
      Console.WriteLine(((DayOfWeek)7).ToString("G"));      // 7
      Console.WriteLine(ConsoleColor.Red.ToString("G"));    // Displays Red

      var attributes = FileAttributes.Hidden | FileAttributes.Archive;
      Console.WriteLine(attributes.ToString("G"));          // Displays Hidden, Archive
      // </Snippet1>
      Console.WriteLine();
   }

   private static void ShowFSpecifier()
   {
      Console.WriteLine("F Specifier:");
      // <Snippet2>
      Console.WriteLine(((DayOfWeek)7).ToString("F"));       // Monday, Saturday
      Console.WriteLine(ConsoleColor.Blue.ToString("F"));    // Displays Blue

      var attributes = FileAttributes.Hidden | FileAttributes.Archive;
      Console.WriteLine(attributes.ToString("F"));           // Displays Hidden, Archive
      // </Snippet2>
      Console.WriteLine();
   }

   private static void ShowDSpecifier()
   {
      Console.WriteLine("D Specifier:");
      // <Snippet3>
      Console.WriteLine(((DayOfWeek)7).ToString("D"));       // 7
      Console.WriteLine(ConsoleColor.Cyan.ToString("D"));    // Displays 11

      var attributes = FileAttributes.Hidden | FileAttributes.Archive;
      Console.WriteLine(attributes.ToString("D"));           // Displays 34
      // </Snippet3>
      Console.WriteLine();
   }

   private static void ShowXSpecifier()
   {
      Console.WriteLine("X Specifier:");
      // <Snippet4>
      Console.WriteLine(((DayOfWeek)7).ToString("X"));       // 00000007
      Console.WriteLine(ConsoleColor.Cyan.ToString("X"));    // Displays 0000000B

      var attributes = FileAttributes.Hidden | FileAttributes.Archive;
      Console.WriteLine(attributes.ToString("X"));           // Displays 00000022
      // </Snippet4>
      Console.WriteLine();
   }

   private static void ShowExample()
   {
      Console.WriteLine("Example:");
      // <Snippet6>
      Color myColor = Color.Green;
      // </Snippet6>

      // <Snippet7>
      Console.WriteLine("The value of myColor is {0}.",
                        myColor.ToString("G"));
      Console.WriteLine("The value of myColor is {0}.",
                        myColor.ToString("F"));
      Console.WriteLine("The value of myColor is {0}.",
                        myColor.ToString("D"));
      Console.WriteLine("The value of myColor is 0x{0}.",
                        myColor.ToString("X"));
      // The example displays the following output to the console:
      //       The value of myColor is Green.
      //       The value of myColor is Green.
      //       The value of myColor is 3.
      //       The value of myColor is 0x00000003.
      // </Snippet7>
   }
}
