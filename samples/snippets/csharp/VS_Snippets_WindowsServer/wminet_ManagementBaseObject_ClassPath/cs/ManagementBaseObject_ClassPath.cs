//<Snippet1>
using System;
using System.Management;

public class Sample 
{    
    public static void Main() 
    {
        // Create a query for classes
        SelectQuery query = 
            new SelectQuery("SELECT * FROM meta_class");

        // Initialize an object searcher with this query
        ManagementObjectSearcher searcher = 
            new ManagementObjectSearcher(query);

        // Get the resulting collection and loop through it
        foreach (ManagementObject classObject in searcher.Get()) 
        {
            Console.WriteLine(
                classObject.ClassPath);
        }
    }
}
//</Snippet1>