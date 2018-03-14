//<Snippet1>
using System; 
using System.Management; 


public class Sample 
{ 
    public static void Main(string[] args) 
    { 
        ManagementObject o = 
            new ManagementObject("Win32_Service='Alerter'"); 

        foreach(ManagementObject b in o.GetRelated()) 
            Console.WriteLine( 
                "Object related to Alerter service : {0}", 
                b.ClassPath); 
    } 
}
//</Snippet1>