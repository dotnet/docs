//<Snippet1>
using System;
using System.Management;
public class RemoteConnect 
{
    public static void Main() 
    {
        EnumerationOptions opt = new EnumerationOptions(
            null, System.TimeSpan.MaxValue,
            1, true, true, false, 
            true, false, false, true);

        ManagementClass c = new ManagementClass("CIM_Service");
        foreach (ManagementObject o in c.GetInstances(opt))
            Console.WriteLine(o["Name"]);
    }
}
//</Snippet1>