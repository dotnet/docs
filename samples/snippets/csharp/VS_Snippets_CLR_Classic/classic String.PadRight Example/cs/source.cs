using System;

public class Sample
{
   public static void Main()
   {
      // <Snippet1>
      string str;
      str = "BBQ and Slaw";
      
      Console.Write("|");
      Console.Write(str.PadRight(15));
      Console.WriteLine("|");       // Displays "|BBQ and Slaw   |".
      
      Console.Write("|");
      Console.Write(str.PadRight(5));
      Console.WriteLine("|");       // Displays "|BBQ and Slaw|".
      // </Snippet1>
   }
}
