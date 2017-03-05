using System;

public class Example
{
   public static void Main()
   {
      // <Snippet2>
      Console.WriteLine(3 is int);
      Console.WriteLine();
      
      int value = 6;
      Console.WriteLine(value is long);
      Console.WriteLine(value is double);
      Console.WriteLine(value is object);
      Console.WriteLine(value is ValueType);
      Console.WriteLine(value is int);
      // Compilation generates the following compiler warnings:
      //   is2.cs(8,25): warning CS0183: The given expression is always of the provided ('int') type
      //   is2.cs(12,25): warning CS0184: The given expression is never of the provided ('long') type
      //   is2.cs(13,25): warning CS0184: The given expression is never of the provided ('double') type
      //   is2.cs(14,25): warning CS0183: The given expression is always of the provided ('object') type
      //   is2.cs(15,25): warning CS0183: The given expression is always of the provided ('ValueType') type
      //   is2.cs(16,25): warning CS0183: The given expression is always of the provided ('int') type
      // </Snippet2>
   }
}

