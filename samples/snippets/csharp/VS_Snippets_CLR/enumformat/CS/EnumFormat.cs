// <Snippet1>
using System;

enum Colors { Red, Green, Blue, Yellow };

public class FormatTest {
    public static void Main() {
        Colors myColor = Colors.Blue;

        Console.WriteLine("My favorite color is {0}.", myColor);
        Console.WriteLine("The value of my favorite color is {0}.", Enum.Format(typeof(Colors), myColor, "d"));
        Console.WriteLine("The hex value of my favorite color is {0}.", Enum.Format(typeof(Colors), myColor, "x"));
    }
}
// The example displays the following output:
//    My favorite color is Blue.
//    The value of my favorite color is 2.
//    The hex value of my favorite color is 00000002.
// </Snippet1>
