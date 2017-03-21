// Add an EventMappingsSettings object to the EventMappings collection property.
healthMonitoringSection.EventMappings.Add(new EventMappingSettings(
    "Success Audits", "System.Web.Management.WebAuditEvent, System.Web",
    512, Int32.MaxValue));