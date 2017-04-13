using System;

// <Snippet1>
enum Shade
{
    White = 0, Gray = 1, Grey = 1, Black = 2 
}
// </Snippet1>

public class Example
{
   public static void Main()
   {
      CallDefault();
      CallWithFormatString();
   }

   private static void CallDefault()
   {   
      // <Snippet2>
      string shadeName = ((Shade) 1).ToString();      
      // </Snippet2>
      Console.WriteLine(shadeName);
   }
   
   private static void CallWithFormatString()
   {
      // <Snippet3>
      string shadeName = ((Shade) 1).ToString("F");
      // </Snippet3>
      Console.WriteLine(shadeName);
   }
}
