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

        ManagementObjectCollection classObjects;
        classObjects = processClass.GetInstances();

        foreach (ManagementObject classObject in
            classObjects)
        {
            Console.WriteLine(
                classObject.GetPropertyValue(
                "Name"));
         
        }
    }
}
//</Snippet1>