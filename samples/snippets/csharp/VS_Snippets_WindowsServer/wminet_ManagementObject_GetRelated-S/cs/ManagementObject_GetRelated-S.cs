//<Snippet1>
using System;
using System.Management;
   
public class Sample
{
    public static void Main(string[] args) 
    {
        ManagementObject o = 
            new ManagementObject("Win32_Service='Alerter'");
    
        foreach (ManagementObject b in
            o.GetRelated("Win32_Service"))

            Console.WriteLine(
                "Service related to the Alerter service {0} is {1}",
                b["Name"], b["State"]);
    }
}
//</Snippet1>