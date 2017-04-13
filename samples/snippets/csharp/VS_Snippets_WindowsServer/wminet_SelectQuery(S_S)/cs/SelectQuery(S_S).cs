//<Snippet1>
using System;
using System.Management;

public class Sample 
{
    public static void Main(string[] args) 
    {
        SelectQuery s = 
            new SelectQuery("Win32_Service",
            "State = 'Stopped'");
        
        ManagementObjectSearcher searcher = 
            new ManagementObjectSearcher(
            s);

        foreach (ManagementObject service in searcher.Get()) 
        {
            // show the class
            Console.WriteLine(service.ToString());
        }
    }
}
//</Snippet1>