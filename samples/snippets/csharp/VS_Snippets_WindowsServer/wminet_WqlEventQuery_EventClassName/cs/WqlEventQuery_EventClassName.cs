//<Snippet1>
using System;
using System.Management;

public class EventSample 
{
    public static void Main(string[] args) 
    {
        WqlEventQuery query = new WqlEventQuery();
        query.EventClassName = "__InstanceCreationEvent";
        query.Condition = "TargetInstance ISA 'Win32_NTLogEvent'";
        query.GroupWithinInterval = new TimeSpan(0, 0, 10);
        System.Collections.Specialized.StringCollection collection =
            new System.Collections.Specialized.StringCollection();
        collection.Add("TargetInstance.SourceName");
        query.GroupByPropertyList = collection;
        query.HavingCondition = "NumberOfEvents > 25";

        Console.WriteLine(query.QueryString);
        return;
    }
}
//</Snippet1>