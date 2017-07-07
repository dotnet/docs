//<Snippet1>
using System;
using System.Management;
   
class Sample
{
    public static int Main(string[] args) 
    {
        ManagementPath p = 
            new ManagementPath(
            "Win32_Service.Name='Alerter'");
        ManagementObject o = new ManagementObject(p);

        //Now it can be used 
        Console.WriteLine(o["Name"]);
        
        return 0;
    }
}
//</Snippet1>