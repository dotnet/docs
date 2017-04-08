// <Snippet7>
using System;

[assembly: CLSCompliant(true)]

public enum Size : uint { 
   Unspecified = 0, 
   XSmall = 1, 
   Small = 2, 
   Medium = 3, 
   Large = 4, 
   XLarge = 5 
};

public class Clothing
{
   public string Name; 
   public string Type;
   public string Size;
}
// The attempt to compile the example displays a compiler warning like the following:
//    Enum3.cs(6,13): warning CS3009: 'Size': base type 'uint' is not CLS-compliant
// </Snippet7>
 