using System;

public class Example15
{
   public static void Main()
   {
      // <Snippet3>
      int integerValue = 60312;
      Console.WriteLine(integerValue.ToString("X"));   // Displays EB98.
      // </Snippet3>

      // <Snippet10>
      double cost = 1632.54;
      Console.WriteLine(cost.ToString("C",
                        new System.Globalization.CultureInfo("en-US")));
      // The example displays the following output:
      //       $1,632.54
      // </Snippet10>
   }
}
