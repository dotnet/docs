//<Snippet1>
using System;
using System.Management;

public class Sample 
{
    public static void Main(string[] args) 
    {
        ManagementObjectSearcher s = 
            new ManagementObjectSearcher(
            "root\\CIMV2", 
            "SELECT * FROM Win32_Service", 
            new EnumerationOptions(
            null, System.TimeSpan.MaxValue,
            1, true, false, true, 
            true, false, true, true));


        foreach (ManagementObject service in s.Get()) 
        {
            // show the service
            Console.WriteLine(service.ToString());
        }
    }
}
//</Snippet1>