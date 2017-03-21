' Add a EventMappingsSettings object to the EventMappings collection property.
Dim eventMappingSetting As EventMappingSettings = New EventMappingSettings( _
    "Failure Audits", "System.Web.Management.WebAuditEvent, System.Web")
eventMappingSetting.Name = "All Errors"
eventMappingSetting.Type = _
    "System.Web.Management.WebErrorEvent, System.Web"
eventMappingSetting.StartEventCode = 0
eventMappingSetting.EndEventCode = 4096
healthMonitoringSection.EventMappings.Add(eventMappingSetting)