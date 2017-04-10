//<Snippet1>
using System;
using System.Management;
   
class Sample
{
    public static int Main(string[] args) 
    {
        ManagementPath p = 
            new ManagementPath("Win32_Service");
   
        // Set options for no context info
        // but requests amended qualifiers 
        // to be contained in the object
        ObjectGetOptions opt = 
            new ObjectGetOptions(
            null, System.TimeSpan.MaxValue, true);    

        ManagementClass c = 
            new ManagementClass(p, opt);
   
        Console.WriteLine(
            c.Qualifiers["Description"].Value);
        
        return 0;
    }
}
//</Snippet1>