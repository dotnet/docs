//<Snippet1>
using System;
using System.Management;

public class Sample 
{
    public static void Main(string[] args) 
    {
        SelectQuery q = 
            new SelectQuery("Win32_Service", 
                "State='Running'");
        ManagementObjectSearcher s = 
            new ManagementObjectSearcher(q);

        foreach (ManagementObject service in s.Get()) 
        {
            // show the instance
            Console.WriteLine(service.ToString());
        }
    }
}
//</Snippet1>