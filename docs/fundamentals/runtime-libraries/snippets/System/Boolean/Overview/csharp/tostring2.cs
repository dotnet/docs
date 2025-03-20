// <Snippet4>
using System;

public class Example11
{
    public static void Main()
    {
        bool raining = false;
        bool busLate = true;

        Console.WriteLine($"It is raining: {(raining ? "Yes" : "No")}");
        Console.WriteLine($"The bus is late: {(busLate ? "Yes" : "No")}");
    }
}
// The example displays the following output:
//       It is raining: No
//       The bus is late: Yes
// </Snippet4>
