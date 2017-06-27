//<Snippet1>
using System;
using System.Management;

public class Sample 
{    
    public static void Main() 
    {
        ManagementClass c = new ManagementClass("Win32_Process");
        foreach (ManagementObject o in c.GetInstances())
            Console.WriteLine(
                "Next instance of Win32_Process : {0}", o["Name"]);

    }
}
//</Snippet1>