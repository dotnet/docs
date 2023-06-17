using System;
using System.IO;

// <Snippet5>
public enum Color {Red = 1, Blue = 2, Green = 3}
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
        DateTime date = new DateTime(2023, 6, 17);
        string formattedValueG = date.ToString("G");
        Console.WriteLine("Formatted value (G): " + formattedValueG);  // Result:17-06-2023 00:00:00
      // </Snippet1>
      Console.WriteLine();
   }

   private static void ShowFSpecifier()
   {
      Console.WriteLine("F Specifier:");
      // <Snippet2>
        DateTime date = new DateTime(2023, 6, 17);
        string formattedValueF = date.ToString("F");
        Console.WriteLine("Formatted value (F): " + formattedValueF);  // Result: 17 June 2023 00:00:00
      // </Snippet2>
      Console.WriteLine();
   }

   private static void ShowDSpecifier()
   {
      Console.WriteLine("D Specifier:");
      // <Snippet3>
      Console.WriteLine(ConsoleColor.Cyan.ToString("D"));         // Displays 11
      FileAttributes attributes = FileAttributes.Hidden |
                                  FileAttributes.Archive;
      Console.WriteLine(attributes.ToString("D"));                // Displays 34
      // </Snippet3>
      Console.WriteLine();
   }

   private static void ShowXSpecifier()
   {
      Console.WriteLine("X Specifier:");
      // <Snippet4>
      Console.WriteLine(ConsoleColor.Cyan.ToString("X"));   // Displays 0000000B
      FileAttributes attributes = FileAttributes.Hidden |
                                  FileAttributes.Archive;
      Console.WriteLine(attributes.ToString("X"));          // Displays 00000022
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
