//<Snippet1>
using System;
using System.Management;

public class Sample 
{
    public static void Main(string[] args) 
    {
        ManagementScope scope = 
            new ManagementScope("root\\CIMV2");
        SelectQuery q = 
            new SelectQuery("SELECT * FROM Win32_LogicalDisk");
        EnumerationOptions o = 
            new EnumerationOptions(
            null, System.TimeSpan.MaxValue,
            1, true, false, true, 
            true, false, true, true);
        ManagementObjectSearcher s = 
            new ManagementObjectSearcher(scope, q, o);

        foreach (ManagementObject disk in s.Get()) 
        {
            // show the disk instance
            Console.WriteLine(disk.ToString());
        }
    }
}
//</Snippet1>