using System;
using System.Diagnostics;

public class SomeClass
{
// <Snippet4>
    private static BooleanSwitch boolSwitch = new BooleanSwitch("mySwitch",
        "Switch in config file");

    public static void Main( )
    {
        //...
        Console.WriteLine("Boolean switch {0} configured as {1}",
            boolSwitch.DisplayName, boolSwitch.Enabled.ToString());
        if (boolSwitch.Enabled)
        {
            //...
        }
    }
// </Snippet4>
}

