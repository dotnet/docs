using System;

public class Sample
{
    public static void Main()
    {
      // <Snippet1>
      string str = "BBQ and Slaw";
      Console.WriteLine(str.PadLeft(15));  // Displays "   BBQ and Slaw".
      Console.WriteLine(str.PadLeft(5));   // Displays "BBQ and Slaw".
      // </Snippet1>
    }
}

