// <Snippet1>
using System;

public class EnumSample {
    enum Colors {Red = 1, Blue = 2};
    
    public static void Main() {
        Enum myColors = Colors.Red;
        Console.WriteLine("The value of this instance is '{0}'",
           myColors.ToString());
    }
}
/*
Output.
The value of this instance is 'Red'.
*/
// </Snippet1>
