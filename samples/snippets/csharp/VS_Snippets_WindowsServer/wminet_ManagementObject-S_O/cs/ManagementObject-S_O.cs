//<Snippet1>
using System;
using System.Management;
   
class Sample
{
    public static int Main(string[] args) 
    {
        // Set options for no context info, 
        // but requests amended qualifiers
        // to be contained in the object
        ObjectGetOptions opt = 
            new ObjectGetOptions(null, System.TimeSpan.MaxValue, true); 

        ManagementObject o = 
            new ManagementObject(
            "Win32_Service", opt);
   
        Console.WriteLine(o.GetQualifierValue("Description"));
        
        return 0;
    }
}
//</Snippet1>