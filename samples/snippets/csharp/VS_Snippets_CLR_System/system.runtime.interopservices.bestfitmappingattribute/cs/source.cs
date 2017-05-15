using System;
using System.Runtime.InteropServices;

// <Snippet1>
[BestFitMapping(false, ThrowOnUnmappableChar = true)]
interface IMyInterface1
{
     //Insert code here.
}
// </Snippet1>

public class InteropBFMA : IMyInterface1
{
    public static void Main()
    {
        InteropBFMA bfma = new InteropBFMA();

        Console.WriteLine(bfma.GetType().GetInterfaces()[0].Name);
    }
}