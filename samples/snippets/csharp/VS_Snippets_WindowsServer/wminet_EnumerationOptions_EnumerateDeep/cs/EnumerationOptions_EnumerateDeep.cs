//<Snippet1>
using System;
using System.Management;
public class RemoteConnect 
{
    public static void Main() 
    {
        EnumerationOptions opt = new EnumerationOptions();

        // Will enumerate instances of the given class
        // and any subclasses.
        opt.EnumerateDeep = true;
        ManagementClass c = new ManagementClass("CIM_Service");
        foreach (ManagementObject o in c.GetInstances(opt))
            Console.WriteLine(o["Name"]);
    }
}
//</Snippet1>