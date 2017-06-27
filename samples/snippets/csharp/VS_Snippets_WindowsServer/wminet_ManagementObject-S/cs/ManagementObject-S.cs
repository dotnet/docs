//<Snippet1>
using System;
using System.Management;
   
class Sample
{
    public static int Main(string[] args) 
    {
        ManagementObject o =
            new ManagementObject("Win32_Service.Name='Alerter'");
   
        //or with a full path :
   
        ManagementObject mObj =
            new ManagementObject(
            "\\\\MyServer\\root\\MyApp:MyClass.Key='abc'");

        return 0;
    }
}
//</Snippet1>