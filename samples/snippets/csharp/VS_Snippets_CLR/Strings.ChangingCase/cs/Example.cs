using System;

[assembly: CLSCompliant(true)]
public class Example
{
   public static void Main()
   {
      ConvertToUpperCase();
      Console.WriteLine();
      ConvertToLowerCase();
   }

   private static void ConvertToUpperCase()
   {
      // <Snippet1>
      string properString = "Hello World!";
      Console.WriteLine(properString.ToUpper());
      // This example displays the following output:
      //       HELLO WORLD!
      // </Snippet1>
   }

   private static void ConvertToLowerCase()
   {
      // <Snippet2>
      string properString = "Hello World!";
      Console.WriteLine(properString.ToLower());
      // This example displays the following output:
      //       hello world!
      // </Snippet2>
   }
}



