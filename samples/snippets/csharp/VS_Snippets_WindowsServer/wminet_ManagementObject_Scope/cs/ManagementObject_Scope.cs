//<Snippet1>
using System;
using System.Management;
public class Sample 
{
    public static void Main() 
    {
        // Create the object with the default namespace
        // (root\cimv2)
        ManagementObject o = new ManagementObject();    

        // Change the scope (=namespace) of this object
        // to the one specified.
        o.Scope = new ManagementScope("root\\CIMV2");
    }
}
//</Snippet1>