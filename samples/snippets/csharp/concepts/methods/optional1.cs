// <Snippet21>
using System;

public class Options
{
    public void ExampleMethod(int required, int optionalInt = default,
                              string? description = default)
   {
        var msg = $"{description ?? "N/A"}: {required} + {optionalInt} = {required + optionalInt}";
        Console.WriteLine(msg);
   }
}
// </Snippet21>

// <Snippet22>
public class OptionsExample
{
   public static void Main()
   {
      var opt = new Options();
      opt.ExampleMethod(10);
      opt.ExampleMethod(10, 2);
      opt.ExampleMethod(12, description: "Addition with zero:");
   }
}
// The example displays the following output:
//      N/A: 10 + 0 = 10
//      N/A: 10 + 2 = 12
//      Addition with zero:: 12 + 0 = 12
// </Snippet22>
