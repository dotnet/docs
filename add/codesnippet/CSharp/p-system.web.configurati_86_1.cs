
// Add a EventMappingsSettings object to the EventMappings collection property.
EventMappingSettings eventMappingSetting = new EventMappingSettings(
    "Failure Audits", "System.Web.Management.WebAuditEvent, System.Web");
eventMappingSetting.Name = "All Errors";
eventMappingSetting.Type = 
    "System.Web.Management.WebErrorEvent, System.Web";
eventMappingSetting.StartEventCode = 0;
eventMappingSetting.EndEventCode = 4096;
healthMonitoringSection.EventMappings.Add(eventMappingSetting);

// Add an EventMappingsSettings object to the EventMappings collection property.
healthMonitoringSection.EventMappings.Add(new EventMappingSettings(
    "Failure Audits", "System.Web.Management.WebAuditEvent, System.Web"));

// Add an EventMappingsSettings object to the EventMappings collection property.
healthMonitoringSection.EventMappings.Add(new EventMappingSettings(
    "Success Audits", "System.Web.Management.WebAuditEvent, System.Web",
    512, Int32.MaxValue));

// Insert an EventMappingsSettings object into the EventMappings collection property.
healthMonitoringSection.EventMappings.Insert(1, 
    new EventMappingSettings("HeartBeats", "", 1, 2));

// Display contents of the EventMappings collection property
Console.WriteLine(
    "EventMappings Collection contains {0} values:", healthMonitoringSection.EventMappings.Count);

// Display all elements.
for (System.Int32 i = 0; i < healthMonitoringSection.EventMappings.Count; i++)
{
eventMappingSetting = healthMonitoringSection.EventMappings[i];
string name = eventMappingSetting.Name;
string type = eventMappingSetting.Type;
int startCd = eventMappingSetting.StartEventCode;
int endCd = eventMappingSetting.EndEventCode;
    string item = "Name='" + name + "', Type='" + type +
        "', StartEventCode =  '" + startCd.ToString() +
        "', EndEventCode =  '" + endCd.ToString() + "'";
    Console.WriteLine("  Item {0}: {1}", i, item);
}

// See if the EventMappings collection property contains the event 'HeartBeats'.
Console.WriteLine("EventMappings contains 'HeartBeats': {0}.",
    healthMonitoringSection.EventMappings.Contains("HeartBeats"));

// Get the index of the 'HeartBeats' event in the EventMappings collection property.
Console.WriteLine("EventMappings index for 'HeartBeats': {0}.",
    healthMonitoringSection.EventMappings.IndexOf("HeartBeats"));

// Get a named EventMappings
eventMappingSetting = healthMonitoringSection.EventMappings["HeartBeats"];

// Remove an EventMappingsSettings object from the EventMappings collection property.
healthMonitoringSection.EventMappings.Remove("HeartBeats");

// Remove an EventMappingsSettings object from the EventMappings collection property.
healthMonitoringSection.EventMappings.RemoveAt(0);

// Clear all EventMappingsSettings object from the EventMappings collection property.
healthMonitoringSection.EventMappings.Clear();
