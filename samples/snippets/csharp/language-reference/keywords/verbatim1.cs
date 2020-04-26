using System;

public class Example
{
   public static void Main()
   {
      // <Snippet1>
      string[] @for = { "John", "James", "Joan", "Jamie" };
      for (int ctr = 0; ctr < @for.Length; ctr++)
      {
         Console.WriteLine($"Here is your gift, {@for[ctr]}!");
      }
      // The example displays the following output:
      //     Here is your gift, John!
      //     Here is your gift, James!
      //     Here is your gift, Joan!
      //     Here is your gift, Jamie!
      // </Snippet1>

      Console.WriteLine();

      // <Snippet2>
      string filename1 = @"c:\documents\files\u0066.txt";
      string filename2 = "c:\\documents\\files\\u0066.txt";

      Console.WriteLine(filename1);
      Console.WriteLine(filename2);
      // The example displays the following output:
      //     c:\documents\files\u0066.txt
      //     c:\documents\files\u0066.txt
      // </Snippet2>

      Console.WriteLine();

      // <Snippet3>
      string s1 = "He said, \"This is the last \u0063hance\x0021\"";
      string s2 = @"He said, ""This is the last \u0063hance\x0021""";

      Console.WriteLine(s1);
      Console.WriteLine(s2);
      // The example displays the following output:
      //     He said, "This is the last chance!"
      //     He said, "This is the last \u0063hance\x0021"
      // </Snippet3>
   }
}
