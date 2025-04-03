using System;

public class Example3
{
    public static void Main()
    {
        CallEII();
        Console.WriteLine("-----");
    }

    private static void CallEII()
    {
        // <Snippet7>
        int codePoint = 1067;
        IConvertible iConv = codePoint;
        char ch = iConv.ToChar(null);
        Console.WriteLine($"Converted {codePoint} to {ch}.");
        // </Snippet7>
    }
}
