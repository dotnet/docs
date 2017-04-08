//<Snippet1>
using System;
using System.Management;
   
class Sample
{
    public static int Main(string[] args) 
    {
        ManagementScope s = new ManagementScope(
            "\\\\MyMachine\\root\\cimv2");
        ManagementPath p = 
            new ManagementPath(
            "Win32_Service");

        // Set options for no context info,
        // but requests amended qualifiers 
        // to be contained in the object
        ObjectGetOptions opt = 
            new ObjectGetOptions(
            null, TimeSpan.MaxValue, true); 

        ManagementObject o = new ManagementObject(s, p, opt);

        Console.WriteLine(o.Qualifiers["Description"].Value);

        return 0;
    }
}
//</Snippet1>