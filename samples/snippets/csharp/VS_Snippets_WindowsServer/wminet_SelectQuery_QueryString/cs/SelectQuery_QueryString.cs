//<Snippet1>
using System;
using System.Management;

public class Sample 
{
    public static void Main(string[] args) 
    {
        SelectQuery s = new SelectQuery(); 
        s.QueryString = "SELECT * FROM Win32_Process";
      
        ManagementObjectSearcher searcher = 
            new ManagementObjectSearcher(
            s);

        foreach (ManagementObject o in searcher.Get()) 
        {
            // show the class
            Console.WriteLine(o.ToString());
        }
    }
}
//</Snippet1>