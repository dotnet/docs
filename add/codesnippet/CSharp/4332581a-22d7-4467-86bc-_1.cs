// Add a EventMappingsSettings object to the EventMappings collection property.
EventMappingSettings eventMappingSetting = new EventMappingSettings(
    "Failure Audits", "System.Web.Management.WebAuditEvent, System.Web");
eventMappingSetting.Name = "All Errors";
eventMappingSetting.Type = 
    "System.Web.Management.WebErrorEvent, System.Web";
eventMappingSetting.StartEventCode = 0;
eventMappingSetting.EndEventCode = 4096;
healthMonitoringSection.EventMappings.Add(eventMappingSetting);