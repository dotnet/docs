//<Snippet1>
using System;
using System.Management;

public class Example
{
    public static void Main() 
    {
        EnumerationOptions opt = new EnumerationOptions();   
        // Causes return of deep subclasses
        // as opposed to only immediate ones.
        opt.EnumerateDeep = true;  
        ManagementObjectCollection subclasses = (new
            ManagementClass("CIM_LogicalDisk")).GetSubclasses(opt);
        foreach(ManagementClass subclass in subclasses)
        {
            Console.WriteLine( "Subclass found: {0}" ,
                subclass["__CLASS"]);
        }

        return;
    }
}
//</Snippet1>