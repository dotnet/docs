//<Snippet1>
using System; 
using System.Management;
 
// This example demonstrates how to
// enumerate all logical disks 
// using the ManagementObjectEnumerator object.
class Sample_ManagementObjectEnumerator 
{
    public static int Main(string[] args) 
    { 
        ManagementClass diskClass = 
            new ManagementClass("Win32_LogicalDisk");
        ManagementObjectCollection disks = 
            diskClass.GetInstances();
        ManagementObjectCollection.ManagementObjectEnumerator
            disksEnumerator =
            disks.GetEnumerator();
        while(disksEnumerator.MoveNext()) 
        { 
            ManagementObject disk = 
                (ManagementObject)disksEnumerator.Current;
            Console.WriteLine(
                "Disk found: " + disk["deviceid"]);
        }
        return 0;
    }
}
//</Snippet1>