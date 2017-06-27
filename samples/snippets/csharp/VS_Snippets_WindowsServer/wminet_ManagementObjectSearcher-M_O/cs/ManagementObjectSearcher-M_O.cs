//<Snippet1>
using System;
using System.Management;

public class Sample 
{
    public static void Main(string[] args) 
    {
        ManagementScope myScope = 
            new ManagementScope("root\\CIMV2");
        SelectQuery q = 
            new SelectQuery("Win32_LogicalDisk");
        ManagementObjectSearcher s = 
            new ManagementObjectSearcher(myScope,q);

        foreach (ManagementObject disk in s.Get()) 
        {
            // show the disk instance
            Console.WriteLine(disk.ToString());
        }
    }
}
//</Snippet1>