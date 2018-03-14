//<Snippet1>
using System;
using System.Management;

public class EventSample 
{
    public static void Main(string[] args) 
    {
        // Requests all instance creation events,
        // with a specified latency of
        // 10 seconds. The query created
        // is "SELECT * FROM __InstanceCreationEvent WITHIN 10"
        WqlEventQuery q = new WqlEventQuery("__InstanceCreationEvent",
            new TimeSpan(0,0,10));


        Console.WriteLine(q.QueryString);
        return;
    }
}
//</Snippet1>