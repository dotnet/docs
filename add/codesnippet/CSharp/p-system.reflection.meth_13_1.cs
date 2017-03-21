using System;
using System.Reflection;

public class Example
{
    public static void Main()
    {
        // Get method body information.
        MethodInfo mi = typeof(Example).GetMethod("MethodBodyExample");
        MethodBody mb = mi.GetMethodBody();
        Console.WriteLine("\r\nMethod: {0}", mi);

        // Display the general information included in the 
        // MethodBody object.
        Console.WriteLine("    Local variables are initialized: {0}", 
            mb.InitLocals);
        Console.WriteLine("    Maximum number of items on the operand stack: {0}", 
            mb.MaxStackSize);