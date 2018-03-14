//<Snippet1>
using System;
using System.Management;

public class Sample 
{
    public static void Main(string[] args) 
    {
        String[] properties = 
            {"Name", "Handle"};

        SelectQuery s = new SelectQuery("Win32_Process",
            "Name = 'notepad.exe'", 
            properties);

        
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