//<Snippet1>
using System;
using System.Management;

public class EventSample 
{
    public static void Main(string[] args) 
    {
        // Requests sending aggregated events
        // if the number of events exceeds 15.
        String[] props = {"TargetInstance.SourceName"};
        WqlEventQuery q = 
            new WqlEventQuery(
            "__InstanceCreationEvent", 
            System.TimeSpan.MaxValue,
            "TargetInstance isa 'Win32_NTLogEvent'", 
            new TimeSpan(0,10,0), 
            props, 
            "NumberOfEvents >15");


        Console.WriteLine(q.QueryString);
        return;
    }
}
//</Snippet1>