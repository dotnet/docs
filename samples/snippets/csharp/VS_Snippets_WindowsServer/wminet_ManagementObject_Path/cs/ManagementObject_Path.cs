//<Snippet1>
using System;
using System.Management;
public class Sample 
{
    public static void Main() 
    {
        ManagementObject o = new ManagementObject(); 

        // Specify the WMI path to which 
        // this object should be bound to
        o.Path = new ManagementPath(
            "Win32_Process.Name='calc.exe'");
    }
}
//</Snippet1>