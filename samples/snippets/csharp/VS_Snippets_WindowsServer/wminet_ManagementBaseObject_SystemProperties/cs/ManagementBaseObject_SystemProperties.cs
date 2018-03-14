//<Snippet1>
using System;
using System.Management;

public class Sample 
{    
    public static void Main() 
    {

        // Get the WMI class
        ManagementClass processClass = 
            new ManagementClass("Win32_Process");

        // Get the system properties for the class
        PropertyDataCollection properties =
            processClass.SystemProperties;

        // display the properties
        foreach (PropertyData p in properties)
        {
            Console.WriteLine(p.Name);
            Console.WriteLine(p.Value);
            Console.WriteLine();

        }
    }
}
//</Snippet1>