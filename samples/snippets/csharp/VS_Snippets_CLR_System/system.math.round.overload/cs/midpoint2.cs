// <Snippet6>
using System;

public class Example
{
   public static void Main()
   {
      Double[] values = { 12.0, 12.1, 12.2, 12.3, 12.4, 12.5, 12.6, 
                          12.7, 12.8, 12.9, 13.0 };
      Console.WriteLine("{0,-10} {1,-10} {2,-10} {3,-15}", "Value", "Default", 
                        "ToEven", "AwayFromZero");
      foreach (var value in values)
         Console.WriteLine("{0,-10:R} {1,-10} {2,-10} {3,-15}",
                           value, Math.Round(value), 
                           Math.Round(value, MidpointRounding.ToEven),
                           Math.Round(value, MidpointRounding.AwayFromZero));
   }
}
// The example displays the following output:
//       Value      Default    ToEven     AwayFromZero
//       12         12         12         12
//       12.1       12         12         12
//       12.2       12         12         12
//       12.3       12         12         12
//       12.4       12         12         12
//       12.5       12         12         13
//       12.6       13         13         13
//       12.7       13         13         13
//       12.8       13         13         13
//       12.9       13         13         13
//       13.0       13         13         13
// </Snippet6>
