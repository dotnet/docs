
' Add a EventMappingsSettings object to the EventMappings collection property.
Dim eventMappingSetting As EventMappingSettings = New EventMappingSettings( _
    "Failure Audits", "System.Web.Management.WebAuditEvent, System.Web")
eventMappingSetting.Name = "All Errors"
eventMappingSetting.Type = _
    "System.Web.Management.WebErrorEvent, System.Web"
eventMappingSetting.StartEventCode = 0
eventMappingSetting.EndEventCode = 4096
healthMonitoringSection.EventMappings.Add(eventMappingSetting)

' Add an EventMappingsSettings object to the EventMappings collection property.
healthMonitoringSection.EventMappings.Add(new EventMappingSettings( _
    "Failure Audits", "System.Web.Management.WebAuditEvent, System.Web"))

' Add an EventMappingsSettings object to the EventMappings collection property.
healthMonitoringSection.EventMappings.Add(new EventMappingSettings( _
    "Success Audits", "System.Web.Management.WebAuditEvent, System.Web", _
    512, Int32.MaxValue))

' Insert an EventMappingsSettings object into the EventMappings collection property.
healthMonitoringSection.EventMappings.Insert(1, _
    new EventMappingSettings("HeartBeats", "", 1, 2))

' Display contents of the EventMappings collection property
Console.WriteLine( _
    "EventMappings Collection contains {0} values:", healthMonitoringSection.EventMappings.Count)

' Display all elements.
For i As System.Int32 = 0 To healthMonitoringSection.EventMappings.Count - 1
eventMappingSetting = healthMonitoringSection.EventMappings(i)
Dim name As String = eventMappingSetting.Name
Dim type As String = eventMappingSetting.Type
Dim startCd As Integer = eventMappingSetting.StartEventCode
Dim endCd As Integer = eventMappingSetting.EndEventCode
    Dim item As String = "Name='" & name & "', Type='" & type & _
        "', StartEventCode =  '" & startCd.ToString() & _
        "', EndEventCode =  '" & endCd.ToString() & "'"
    Console.WriteLine("  Item {0}: {1}", i, item)
Next

' See if the EventMappings collection property contains the event 'HeartBeats'.
Console.WriteLine("EventMappings contains 'HeartBeats': {0}.", _
    healthMonitoringSection.EventMappings.Contains("HeartBeats"))

' Get the index of the 'HeartBeats' event in the EventMappings collection property.
Console.WriteLine("EventMappings index for 'HeartBeats': {0}.", _
    healthMonitoringSection.EventMappings.IndexOf("HeartBeats"))

' Get a named EventMappings
eventMappingSetting = healthMonitoringSection.EventMappings("HeartBeats")

' Remove an EventMappingsSettings object from the EventMappings collection property.
healthMonitoringSection.EventMappings.Remove("HeartBeats")

' Remove an EventMappingsSettings object from the EventMappings collection property.
healthMonitoringSection.EventMappings.RemoveAt(0)

' Clear all EventMappingsSettings object from the EventMappings collection property.
healthMonitoringSection.EventMappings.Clear()
