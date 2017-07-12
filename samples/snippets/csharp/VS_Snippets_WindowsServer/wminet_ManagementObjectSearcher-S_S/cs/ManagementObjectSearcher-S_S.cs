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
            "SELECT * FROM Win32_Service" +
            " WHERE State='Running'");

        foreach (ManagementObject service in s.Get()) 
        {
            // show the instance
            Console.WriteLine(service.ToString());
        }
    }
}
//</Snippet1>