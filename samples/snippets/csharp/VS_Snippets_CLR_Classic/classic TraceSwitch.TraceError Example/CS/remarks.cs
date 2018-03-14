// <Snippet2>
using System;
using System.Diagnostics;

public class TraceErr
{
// <Snippet3>
    private static TraceSwitch appSwitch = new TraceSwitch("mySwitch",
        "Switch in config file");

    public static void Main(string[] args)
    {
        //...
        Console.WriteLine("Trace switch {0} configured as {1}",
        appSwitch.DisplayName, appSwitch.Level.ToString());
        if (appSwitch.TraceError)
        {
            //...
        }
    }
    // </Snippet3>
}
// </Snippet2>
