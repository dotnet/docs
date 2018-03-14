using System;

public class Class1
{
   public static void Main()
   {
      // <Snippet1>
      DateTime date1 = new DateTime(2008, 4, 1, 18, 53, 0);
      Console.WriteLine(date1.ToString("%h"));              // Displays 6 
      Console.WriteLine(date1.ToString("h tt"));            // Displays 6 PM
      // </Snippet1>
   }
}
