//<Snippet1>
using System;
using System.Management;
   
public class Sample
{
    public static void Main(string[] args) 
    {
        ManagementObject m = new ManagementObject(
            "Win32_LogicalDisk.DeviceID=\"C:\"");
        Console.WriteLine("Free space on drive C is: " +
            m.Properties["Freespace"].Value + " bytes");
    }
}
//</Snippet1>