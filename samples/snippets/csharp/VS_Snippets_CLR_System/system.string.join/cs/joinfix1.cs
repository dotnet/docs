using System;

public class Example
{
   public static void Main()
   {
      // <Snippet6>
      object[] values = { null, "Cobb", 4189, 11434, .366 };
      if (values[0] == null) values[0] = String.Empty;
      Console.WriteLine(String.Join("|", values));
      // The example displays the following output:
      //      |Cobb|4189|11434|0.366
      // </Snippet6>
   }
}
