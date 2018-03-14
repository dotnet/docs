//<Snippet1>
using System;
using System.Management;

public class Example
{
    public static void Main() 
    {
        ManagementClass c = 
            new ManagementClass("Win32_Process");
        foreach (MethodData m in c.Methods)
            Console.WriteLine(
                "The class contains this method: {0}", m.Name);
        return;
    }
}
//</Snippet1>