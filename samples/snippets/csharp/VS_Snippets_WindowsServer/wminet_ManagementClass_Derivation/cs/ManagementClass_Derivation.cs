//<Snippet1>
using System;
using System.Management;

public class Example
{
    public static void Main() 
    {
        ManagementClass c = 
            new ManagementClass("Win32_LogicalDisk");
        foreach (string s in c.Derivation)
            Console.WriteLine("Further derived from : {0}", s);

        return;
    }
}
//</Snippet1>