//<Snippet1>
using System;
using System.Management;

public class Sample 
{
    public static void Main(string[] args) 
    {
        ManagementScope ms = new ManagementScope(
            "\\\\.\\root\\cimv2");
        ms.Connect();
        ManagementObjectSearcher searcher = 
            new ManagementObjectSearcher(
            "SELECT * FROM Win32_Service");
        searcher.Scope = ms;

        foreach (ManagementObject service in searcher.Get()) 
        {
            // show the service
            Console.WriteLine(service.ToString());
        }
    }
}
//</Snippet1>