//<Snippet1>
using System;
using System.Management;

public class EventSample 
{
    public static void Main(string[] args) 
    {
        // Requests notification of the creation
        // of Win32_Service instances with
        // a 10 second allowed latency.
        WqlEventQuery q = new WqlEventQuery("__InstanceCreationEvent", 
            new TimeSpan(0,0,10), 
            "TargetInstance isa 'Win32_Service'");

        Console.WriteLine(q.QueryString);
        return;
    }
}
//</Snippet1>