//<Snippet1>
using System;
using System.Management;

public class Sample
{
    public static void Main() 
    {
        ManagementClass c =
            new ManagementClass("Win32_LogicalDisk");

        foreach (ManagementClass r in c.GetRelatedClasses())
            Console.WriteLine(
                "Instances of {0} are related to this class",
                r["__CLASS"]);

        return;
    }
}
//</Snippet1>