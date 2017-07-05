//<Snippet1>
using System;
using System.Management;
   
class Sample
{
    public static int Main(string[] args) 
    {
        ManagementObject o = new ManagementObject();

        // Now set the path on this object to
        // bind it to a 'real' manageable entity
        o.Path = 
            new ManagementPath("Win32_LogicalDisk='c:'"); 

        //Now it can be used 
        Console.WriteLine(o["FreeSpace"]);
        
        return 0;
    }
}
//</Snippet1>