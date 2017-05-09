//<Snippet1>
using System;
using System.Management;

public class Sample 
{
    public static void Main(string[] args) 
    {
        ManagementObjectSearcher s = 
            new ManagementObjectSearcher(
                "SELECT * FROM Win32_Service");

        foreach (ManagementObject service in s.Get()) 
        {
            // show the instance
            Console.WriteLine(service.ToString());
        }
    }
}
//</Snippet1>