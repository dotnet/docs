using System;

public class Example
{
   public static void Main()
   {
      // <Snippet1>
      string MyString = "Jan 1, 2009";
      DateTime MyDateTime = DateTime.Parse(MyString);
      Console.WriteLine(MyDateTime);
      // Displays the following output on a system whose culture is en-US:
      //       1/1/2009 12:00:00 AM
      // </Snippet1>
   }
}
