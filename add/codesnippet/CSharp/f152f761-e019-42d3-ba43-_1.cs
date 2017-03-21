// Add an EventMappingsSettings object to the EventMappings collection property.
healthMonitoringSection.EventMappings.Add(new EventMappingSettings(
    "Failure Audits", "System.Web.Management.WebAuditEvent, System.Web"));